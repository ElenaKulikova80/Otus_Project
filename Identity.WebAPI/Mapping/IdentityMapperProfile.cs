using AutoMapper;
using Identity.WebAPI.Models;
//using Identity.WebAPI.DTO;

namespace Identity.WebAPI.Mapping
{
    public class IdentityMapperProfile : Profile
    {
        public IdentityMapperProfile()
        {
            CreateMap<ApplicationUserRegisterModel, ApplicationUser>()
                    .ForMember(dto => dto.AccessFailedCount, us => us.Ignore())
                    .ForMember(dto => dto.ConcurrencyStamp, us => us.Ignore())
                    .ForMember(dto => dto.EmailConfirmed, us => us.Ignore())
                    .ForMember(dto => dto.LockoutEnabled, us => us.Ignore())
                    .ForMember(dto => dto.LockoutEnd, us => us.Ignore())
                    .ForMember(dto => dto.NormalizedEmail, us => us.Ignore())
                    .ForMember(dto => dto.NormalizedUserName, us => us.Ignore())
                    .ForMember(dto => dto.PasswordHash, us => us.Ignore())
                    .ForMember(dto => dto.PhoneNumber, us => us.Ignore())
                    .ForMember(dto => dto.PhoneNumberConfirmed, us => us.Ignore())
                    .ForMember(dto => dto.SecurityStamp, us => us.Ignore())
                    .ForMember(dto => dto.TwoFactorEnabled, us => us.Ignore());

            CreateMap<ApplicationUserAuthenticationModel, ApplicationUser>()
                    .ForMember(dto => dto.AccessFailedCount, us => us.Ignore())
                    .ForMember(dto => dto.ConcurrencyStamp, us => us.Ignore())
                    .ForMember(dto => dto.EmailConfirmed, us => us.Ignore())
                    .ForMember(dto => dto.LockoutEnabled, us => us.Ignore())
                    .ForMember(dto => dto.LockoutEnd, us => us.Ignore())
                    .ForMember(dto => dto.NormalizedEmail, us => us.Ignore())
                    .ForMember(dto => dto.NormalizedUserName, us => us.Ignore())
                    .ForMember(dto => dto.PasswordHash, us => us.Ignore())
                    .ForMember(dto => dto.PhoneNumber, us => us.Ignore())
                    .ForMember(dto => dto.PhoneNumberConfirmed, us => us.Ignore())
                    .ForMember(dto => dto.SecurityStamp, us => us.Ignore())
                    .ForMember(dto => dto.TwoFactorEnabled, us => us.Ignore());

        }
    }
}
