﻿using AutoMapper;
using SGT.Application.Dtos.Request;
using SGT.Application.Dtos.Response;
using SGT.Application.Interfaces;
using SGT.Domain.Entities;
using SGT.Infrastructure.Persistence.Interfaces;

namespace SGT.Application.Services
{
    public class ApplicationRoleService : IApplicationRoleApplication
    {
        private readonly IApplicationRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public ApplicationRoleService(IApplicationRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleResponseDto>> GetRolesAsync()
        {
            var rolesEntity = await _roleRepository.GetRolesAsync();

            return _mapper.Map<IEnumerable<RoleResponseDto>>(rolesEntity);
        }
        
        public async Task<RoleResponseDto?> GetRoleByIdAsync(string roleId)
        {
            var roleEntity = await _roleRepository.GetRoleByIdAsync(roleId);

            return _mapper.Map<RoleResponseDto>(roleEntity);
        }

        public async Task<RoleResponseDto?> GetRoleByNameAsync(string roleName)
        {
            var roleEntity = await _roleRepository.GetRoleByNameAsync(roleName);

            return _mapper.Map<RoleResponseDto>(roleEntity);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleRepository.RoleExistsAsync(roleName);
        }

        public async Task<bool> CreateRoleAsync(CreateApplicationRoleRequestDto role)
        {
            var roleEntity = _mapper.Map<ApplicationRole>(role);

            return await _roleRepository.CreateRoleAsync(roleEntity);
        }

        public async Task<bool> UpdateRoleAsync(UpdateApplicationRoleRequestDto role)
        {
            var roleEntity = await _roleRepository.GetRoleByIdAsync(role.Id!);
            roleEntity = _mapper.Map(role, roleEntity);

            return await _roleRepository.UpdateRoleAsync(roleEntity!);
        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            return await _roleRepository.DeleteRoleAsync(roleId);
        }
                
    }
}
