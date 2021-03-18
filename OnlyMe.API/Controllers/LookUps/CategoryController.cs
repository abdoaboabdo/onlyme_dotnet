using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlyMe.API.BaseController;
using OnlyMe.DAL.Entities.Categories;
using OnlyMe.DAL.Models;
using OnlyMe.DAL.Models.Categories;
using OnlyMe.Services.Services.CategoriesService;

namespace OnlyMe.API.Controllers.LookUps
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<ICategoryService, Category, CategoryVM, int>
    {
        public CategoryController(ICategoryService categoryService):base(categoryService)
        {

        }

        [HttpGet]
        public IActionResult GetPagedResult([FromQuery] QueryModel queryModel)
        {
            return base.Index(queryModel, m => m.Include(a => a.Variety));
        }
        [HttpGet("GetAll")]
        public virtual async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }
        [HttpPost]
        public virtual async Task<IActionResult> CreateCategory([FromForm] CategoryVM model)
        {
            return await base.Create(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await base.GetById(x => x.Id == id,m => m.Include(a => a.Variety));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> CategoryDelete(int id)

        {
            var category = await base.GetFirstOrDefault(x => x.Id == id && x.Variety.Any(f => f.IsDeleted == false),
                null,
                m => m.Include(a => a.Variety));
            if (category.Variety.Count()>0)
            {
                return BadRequest(new ResponseVM { IsSuccess = false, Message = "This Object Has refrance object in other table" });
            }
            return await base.Delete(id);
        }

    }
}
