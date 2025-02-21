using AutoMapper;
using SGT.Application.Dtos.Request;
using SGT.Application.Dtos.Response;
using SGT.Domain.Entities;

namespace SES_ERP.Application.Mappers.Profiles
{
    public class ApplicationRoleMappingsProfile : Profile
    {
        public ApplicationRoleMappingsProfile()
        {
            CreateMap<CreateApplicationRoleRequestDto, ApplicationRole>();

            CreateMap<UpdateApplicationRoleRequestDto, ApplicationRole>();

            CreateMap<ApplicationRole, RoleResponseDto>();
        }
    }
}
