using Microsoft.AspNetCore.Identity;

namespace SGT.Infrastructure.Models
{
    public class ApplicationRoleModel : IdentityRole
    {
        public string? Description { get; set; }
    }
}
