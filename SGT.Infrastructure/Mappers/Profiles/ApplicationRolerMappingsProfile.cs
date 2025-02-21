using AutoMapper;
using SGT.Domain.Entities;
using SGT.Infrastructure.Models;

namespace SES_ERP.Infrastructure.Mappers.Profiles
{
    public class ApplicationRoleMappingsProfile : Profile
    {
        public ApplicationRoleMappingsProfile()
        {
            CreateMap<ApplicationRoleModel, ApplicationRole>()
                .ReverseMap();
        }
    }
}
