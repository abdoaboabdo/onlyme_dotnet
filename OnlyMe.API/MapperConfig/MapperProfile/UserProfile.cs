using AutoMapper;
using OnlyMe.DAL.Entities;
using OnlyMe.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserProfileVM>();
            CreateMap<UserProfileVM, ApplicationUser>();
        }
    }
}
