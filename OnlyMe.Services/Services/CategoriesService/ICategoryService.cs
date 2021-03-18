using OnlyMe.DAL.Entities.Categories;
using OnlyMe.DAL.Models.Categories;
using OnlyMe.Services.BaseService;

namespace OnlyMe.Services.Services.CategoriesService
{
    public interface ICategoryService : IService<Category, CategoryVM,int>
    {
    }
}
