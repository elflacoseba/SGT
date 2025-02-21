using SGT.Domain.Entities;

namespace SGT.Infrastructure.Persistence.Interfaces
{
    public interface IApplicationRoleRepository
    {
        Task<IEnumerable<ApplicationRole>?> GetRolesAsync();
        Task<ApplicationRole?> GetRoleByIdAsync(string roleId);
        Task<ApplicationRole?> GetRoleByNameAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
        Task<bool> CreateRoleAsync(ApplicationRole role);
        Task<bool> UpdateRoleAsync(ApplicationRole role);
        Task<bool> DeleteRoleAsync(string roleId);
    }
}
