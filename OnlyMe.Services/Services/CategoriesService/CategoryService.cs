using AutoMapper;
using OnlyMe.DAL.Entities.Categories;
using OnlyMe.DAL.Models.Categories;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.Services.Services.CategoriesService
{
    public class CategoryService : BaseService<Category, CategoryVM, int>, ICategoryService
    {
        public CategoryService(IRepository<Category,int> repository, IMapper mapper) : base(repository, mapper)
        {

        }
        public override CategoryVM MapEntityToModel(Category entity)
        {
            return _mapper.Map<CategoryVM>(entity);
        }
        public override Category MapModelToEntity(CategoryVM entity)
        {
            return _mapper.Map<Category>(entity);
        }
        protected override Func<Category, CategoryVM> FuncToVM()
        {
            return c => MapEntityToModel(c);
        }
    }
}
