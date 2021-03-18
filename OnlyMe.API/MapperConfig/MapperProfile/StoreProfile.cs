using AutoMapper;
using OnlyMe.DAL.Entities.Stores;
using OnlyMe.DAL.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig.MapperProfile
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreVM>();
            CreateMap<StoreVM, Store>();
        }
    }
}
