using SGT.Application.Dtos.Request;
using SGT.Application.Dtos.Response;

namespace SGT.Application.Interfaces
{
    public interface IApplicationRoleApplication
    {
        Task<IEnumerable<RoleResponseDto>> GetRolesAsync();
        Task<RoleResponseDto?> GetRoleByIdAsync(string roleId);
        Task<RoleResponseDto?> GetRoleByNameAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
        Task<bool> CreateRoleAsync(CreateApplicationRoleRequestDto role);
        Task<bool> UpdateRoleAsync(UpdateApplicationRoleRequestDto role);
        Task<bool> DeleteRoleAsync(string roleId);
    }
}
