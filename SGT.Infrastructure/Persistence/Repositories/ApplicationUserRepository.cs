﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGT.Domain.Entities;
using SGT.Infrastructure.Models;
using SGT.Infrastructure.Persistence.Interfaces;


namespace SGT.Infrastructure.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {        
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly IMapper _mapper;

        public ApplicationUserRepository(UserManager<ApplicationUserModel> userManager, IMapper mapper)
        {
            _userManager = userManager;            
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            var users = await _userManager.Users.AsNoTracking().ToListAsync();

            return _mapper.Map<IEnumerable<ApplicationUser>>(users);
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            var userModel = await _userManager.FindByIdAsync(userId);

            if (userModel == null)
            {
                return null;
            }

            return _mapper.Map<ApplicationUser>(userModel);
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            var userModel = await _userManager.FindByEmailAsync(email);

            if (userModel == null)
            {
                return null;
            }

            return _mapper.Map<ApplicationUser>(userModel);
        }

        public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
        {
            var userModel = _mapper.Map<ApplicationUserModel>(user);

            var result = await _userManager.CreateAsync(userModel, password);
            
            return result.Succeeded;
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            var userModel = await _userManager.FindByIdAsync(user.Id);

            userModel!.UserName = user.UserName;
            userModel!.Email = user.Email;
            userModel!.PhoneNumber = user.PhoneNumber;            
            userModel!.FirstName = user.FirstName;
            userModel!.LastName = user.LastName;
            
            var result = await _userManager.UpdateAsync(userModel!);           

            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var userModel = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var result = await _userManager.DeleteAsync(userModel!);
            
            return result.Succeeded;
        }

        #region Roles

        /// <summary>
        /// Devuelve los roles de un usuario.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<string>> GetRolesAsync(string userId)
        {
            var userModel = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(userModel!);

            return userRoles;
        }

        public async Task<bool> AddToRoleAsync(string userId, string roleName)
        {
            var userModel = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.AddToRoleAsync(userModel!, roleName);

            return result.Succeeded;
        }

        public async Task<bool> AddToRolesAsync(string userId, IEnumerable<string> roleNames)
        {
            var userModel = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.AddToRolesAsync(userModel!, roleNames);

            return result.Succeeded;
        }

        public async Task<bool> RemoveFromRoleAsync(string userId, string roleName)
        {
            var userModel = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.RemoveFromRoleAsync(userModel!, roleName);

            return result.Succeeded;
        }

        public async Task<bool> RemoveFromRolesAsync(string userId, IEnumerable<string> roleNames)
        {
            var userModel = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.RemoveFromRolesAsync(userModel!, roleNames);

            return result.Succeeded;
        }        

        #endregion
    }
}