﻿using AutoMapper;
using CompanyWatchListEF.Entities;
using CompanyWatchListCore.Models;

namespace CompanyWatchListCore.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegistrationModel, User>()
                .ForMember(dst => dst.UserRoles, opt => opt.Ignore());
            //CreateMap<CompanySearchResultModel, Company>();                                
        }
    }
}
