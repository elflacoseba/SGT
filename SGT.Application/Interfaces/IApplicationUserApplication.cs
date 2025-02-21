using SGT.Application.Dtos.Request;
using SGT.Application.Dtos.Response;

namespace SGT.Application.Interfaces
{
    public interface IApplicationUserApplication
    {
        #region Users
        
        Task<IEnumerable<UserResponseDto>> GetUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(string userId);
        Task<UserResponseDto?> GetUserByEmailAsync(string email);
        Task<bool> CreateUserAsync(CreateApplicationUserRequestDto user);
        Task<bool> UpdateUserAsync(UpdateApplicationUserRequestDto user);
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
