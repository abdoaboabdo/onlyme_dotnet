using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnlyMe.API.BaseController;
using OnlyMe.DAL.Entities.Varieties;
using OnlyMe.DAL.Models;
using OnlyMe.DAL.Models.Varieties;
using OnlyMe.Services.Services.CategoriesService;
using OnlyMe.Services.Services.VarietiesService;

namespace OnlyMe.API.Controllers.LookUps
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarietyController : BaseController<IVarietyService, Variety, VarietyVM, int>
    {
        private readonly ICategoryService categoryService;

        public VarietyController(IVarietyService varietyService, ICategoryService categoryService) :base(varietyService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetPagedResult([FromQuery] QueryModel queryModel)
        {
            return base.Index(queryModel, m => m.Include(a => a.Category));
        }
        [HttpGet("GetAll")]
        public virtual async Task<IActionResult> GetAll([FromQuery] int? CategoryId)
        {
            Expression<Func<Variety, bool>> predicate = x => x.CategoryId == CategoryId;
            bool v = CategoryId != null;
            return await base.GetAll(predicate: v ? predicate : null);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await base.GetById(x => x.Id == id, m => m.Include(a => a.Category));
        }
        [HttpPost]
        public virtual async Task<IActionResult> CreateVariety([FromForm] VarietyVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await categoryService.GetById(model.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError("error", "there is not VarietyId with the given number");
            }
            return await base.Create(model);
        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> VarietyDelete(int id)

        {
            return await base.Delete(id);
        }
    }
}
