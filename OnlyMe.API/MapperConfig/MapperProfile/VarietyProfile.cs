using AutoMapper;
using OnlyMe.DAL.Entities.Varieties;
using OnlyMe.DAL.Models.Varieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig.MapperProfile
{
    public class VarietyProfile : Profile
    {
        public VarietyProfile()
        {
            CreateMap<Variety, VarietyVM>();
            CreateMap<VarietyVM, Variety>();
        }
    }
}
