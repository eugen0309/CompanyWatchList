using AutoMapper;
using CompanyWatchList.Entities;
using CompanyWatchList.Models;
using CompanyWatchList.Services;
using System.Collections.Generic;

namespace CompanyWatchList.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegistrationModel, User>()
                .ForMember(dst => dst.UserRoles, opt => opt.Ignore());
                                
        }
    }
}
