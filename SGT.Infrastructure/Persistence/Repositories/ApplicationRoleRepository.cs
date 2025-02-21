﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGT.Domain.Entities;
using SGT.Infrastructure.Models;
using SGT.Infrastructure.Persistence.Interfaces;

namespace SGT.Infrastructure.Persistence.Repositories
{
    public class ApplicationRoleRepository : IApplicationRoleRepository
    {
        private readonly RoleManager<ApplicationRoleModel> _roleManager;
        private readonly IMapper _mapper;
 
        public ApplicationRoleRepository(RoleManager<ApplicationRoleModel> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationRole>?> GetRolesAsync()
        {
            var rolesModel = await _roleManager.Roles.AsNoTracking().ToListAsync();

            if (rolesModel == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<ApplicationRole>>(rolesModel);
        }

        public async Task<ApplicationRole?> GetRoleByIdAsync(string roleId)
        {
            var roleModel = await _roleManager.FindByIdAsync(roleId);

            if (roleModel == null)
            {
                return null;
            }

            return _mapper.Map<ApplicationRole>(roleModel);
        }

        public async Task<ApplicationRole?> GetRoleByNameAsync(string roleName)
        {
            var roleModel = await _roleManager.FindByNameAsync(roleName);

            if (roleModel == null)
            {
                return null;
            }

            return _mapper.Map<ApplicationRole>(roleModel);
        }
        
        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> CreateRoleAsync(ApplicationRole role)
        {
            var roleModel = _mapper.Map<ApplicationRoleModel>(role);

            var result = await _roleManager.CreateAsync(roleModel);

            return result.Succeeded;
        }

        public async Task<bool> UpdateRoleAsync(ApplicationRole role)
        {
            var roleModel = await _roleManager.FindByIdAsync(role.Id);

            roleModel!.Name = role.Name;
            roleModel!.Description = role.Description;

            var result = await _roleManager.UpdateAsync(roleModel!);

            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            var roleModel = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            var result = await _roleManager.DeleteAsync(roleModel!);

            return result.Succeeded;
        }
        
    }
}
