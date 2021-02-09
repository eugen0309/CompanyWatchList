using AutoMapper;
using CompanyWatchList.Entities;
using CompanyWatchList.Models;

namespace CompanyWatchList.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegistrationModel, User>();
        }
    }
}
