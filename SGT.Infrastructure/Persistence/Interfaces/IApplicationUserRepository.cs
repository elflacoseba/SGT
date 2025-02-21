﻿using SGT.Domain.Entities;

namespace SGT.Infrastructure.Persistence.Interfaces
{
    public interface IApplicationUserRepository
    {
        #region Users

        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<ApplicationUser?> GetUserByEmailAsync(string email);
        Task<bool> CreateUserAsync(ApplicationUser user, string password);
        Task<bool> UpdateUserAsync(ApplicationUser user);
        Task<bool> DeleteUserAsync(string userId);
        
        #endregion

        #region Roles

        Task<IList<string>> GetRolesAsync(string userId);
        Task<bool> AddToRoleAsync(string userId, string roleName);
        Task<bool> AddToRolesAsync(string userId, IEnumerable<string> roleNames);
        Task<bool> RemoveFromRoleAsync(string userId, string roleName);
        Task<bool> RemoveFromRolesAsync(string userId, IEnumerable<string> roleNames);

        #endregion

    }
}
