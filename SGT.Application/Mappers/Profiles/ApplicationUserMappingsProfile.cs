using AutoMapper;
using SGT.Application.Dtos.Request;
using SGT.Application.Dtos.Response;
using SGT.Domain.Entities;

namespace SGT.Application.Mappers.Profiles
{
    public class ApplicationUserMappingsProfile : Profile
    {
        public ApplicationUserMappingsProfile()
        {
            CreateMap<CreateApplicationUserRequestDto, ApplicationUser>();

            CreateMap<UpdateApplicationUserRequestDto, ApplicationUser>();

            CreateMap<ApplicationUser, UserResponseDto>();
        }
    }
}
