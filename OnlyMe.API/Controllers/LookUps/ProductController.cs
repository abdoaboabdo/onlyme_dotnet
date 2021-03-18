using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlyMe.API.BaseController;
using OnlyMe.DAL.Entities.Products;
using OnlyMe.DAL.Models;
using OnlyMe.DAL.Models.Products;
using OnlyMe.Services.Services.ProductsService;
using OnlyMe.Services.Services.VarietiesService;

namespace OnlyMe.API.Controllers.LookUps
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<IProductService, Product, ProductVM, int>
    {
        private readonly IVarietyService _varietyService;

        public ProductController(IProductService service, IVarietyService varietyService) : base(service)
        {
            this._varietyService = varietyService;
        }

        [HttpGet("GetAll")]
        public virtual async Task<IActionResult> GetAll([FromQuery] int? varietyId)
        {
            Expression<Func<Product, bool>> predicate = x => x.VarietyId == varietyId;
            bool v = varietyId != null;
            return await base.GetAll(predicate: v ? predicate : null);
        }

        [HttpGet]
        public IActionResult GetPagedResult([FromQuery] QueryModel queryModel)
        {
            return base.Index(queryModel, m => m.Include(a => a.Variety));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await base.GetById(x => x.Id == id, m => m.Include(a => a.Variety));
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateProduct([FromForm] ProductVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var variety = await _varietyService.GetById(model.VarietyId);
            if (variety==null)
            {
                ModelState.AddModelError("error", "there is not VarietyId with the given number");
            }
            return await base.Create(model);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> CategoryDelete(int id)

        {
            return await base.Delete(id);
        }
    }
}
