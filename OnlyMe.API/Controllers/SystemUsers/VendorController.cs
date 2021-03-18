using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlyMe.API.BaseController;
using OnlyMe.DAL.Entities.Vendors;
using OnlyMe.DAL.Models;
using OnlyMe.DAL.Models.Vendors;
using OnlyMe.Services.Services.VendorService;

namespace OnlyMe.API.Controllers.SystemUsers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseController<IVendorService, Vendor, VendorVM, int>
    {
        public VendorController(IVendorService vendorService) : base(vendorService)
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
        public virtual async Task<IActionResult> CreateVendor([FromForm] VendorVM model)
        {
            return await base.Create(model);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await base.GetById(x => x.Id == id);
        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> VendorDelete(int id)
        {
            return await base.Delete(id);
        }
    }
}
