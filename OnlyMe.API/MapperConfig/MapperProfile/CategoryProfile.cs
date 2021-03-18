using AutoMapper;
using OnlyMe.DAL.Entities.Categories;
using OnlyMe.DAL.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig.MapperProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryVM>();
            //CreateMap<Func<IQueryable<CategoryVM>, IOrderedQueryable<CategoryVM>>,
            //          Func<IQueryable<Category>, IOrderedQueryable<Category>>>();
            CreateMap<CategoryVM, Category>();
        }
    }
}
