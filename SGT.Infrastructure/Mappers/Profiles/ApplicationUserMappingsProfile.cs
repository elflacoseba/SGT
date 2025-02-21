using AutoMapper;
using SGT.Domain.Entities;
using SGT.Infrastructure.Models;

namespace SES_ERP.Infrastructure.Mappers.Profiles
{
    public class ApplicationUserMappingsProfile : Profile
    {
        public ApplicationUserMappingsProfile()
        {
            CreateMap<ApplicationUserModel, ApplicationUser>()
                .ReverseMap();
        }
    }
}
