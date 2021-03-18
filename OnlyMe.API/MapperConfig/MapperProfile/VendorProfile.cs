using AutoMapper;
using OnlyMe.DAL.Entities.Vendors;
using OnlyMe.DAL.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig.MapperProfile
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<Vendor, VendorVM>();
            CreateMap<VendorVM, Vendor>();
        }
    }
}
