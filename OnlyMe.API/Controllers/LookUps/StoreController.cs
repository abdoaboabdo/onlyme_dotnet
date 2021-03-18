using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlyMe.API.BaseController;
using OnlyMe.DAL.Entities.Stores;
using OnlyMe.DAL.Models;
using OnlyMe.DAL.Models.Stores;
using OnlyMe.Services.Services.StoresService;

namespace OnlyMe.API.Controllers.LookUps
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController<IStoreService, Store, StoreVM, int>
    {
        public StoreController(IStoreService storeService):base(storeService)
        {

        }
        [HttpGet]
        public IActionResult GetPagedResult([FromQuery] QueryModel queryModel)
        {
            return base.Index(queryModel);
        }
        [HttpGet("GetAll")]
        public virtual async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateCategory([FromForm] StoreVM model)
        {
            return await base.Create(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await base.GetById(x => x.Id == id);
        }

        //[HttpDelete("{id}")]
        //public virtual async Task<IActionResult> CategoryDelete(int id)

        //{
        //    return await base.Delete(id);
        //}
    }
}
