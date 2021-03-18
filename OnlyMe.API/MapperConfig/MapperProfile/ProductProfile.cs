using AutoMapper;
using OnlyMe.DAL.Entities.Products;
using OnlyMe.DAL.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig.MapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();
        }
    }
}
