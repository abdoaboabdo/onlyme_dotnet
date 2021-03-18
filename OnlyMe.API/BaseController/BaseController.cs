using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using OnlyMe.DAL;
using OnlyMe.DAL.Models;
using OnlyMe.Services.BaseService;

namespace OnlyMe.API.BaseController
{
    public abstract class BaseController<Service, T, TVM, TKey> : ControllerBase
        where Service : IService<T, TVM, TKey>
        where T : BaseEntity<TKey>
        where TVM : BaseVM<TKey>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        private readonly Service _service;
        public BaseController(Service service)
        {
            _service = service;
        }
        protected virtual IActionResult Index(QueryModel queryModel, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var pagedResult = _service.GetPagedResult(queryModel,include);
            return Ok(pagedResult);
        }
        //[HttpGet("GetAll")]
        protected virtual async Task<IActionResult> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false
            )
        {
            return Ok(await _service.GetTOList(predicate, orderBy, include, disableTracking, ignoreQueryFilters));
        }
        //[HttpGet("{id}")]
        protected virtual async Task<IActionResult> GetById(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true)
        {
            var viewModel = await this.GetFirstOrDefault(predicate: predicate,include:include);
            if (viewModel == null)
            {
                ModelState.AddModelError("", "Not Found Object");
                return NotFound(new ResponseVM { IsSuccess = false, Message = "Not Found Object" });
            }
            return Ok(new ResponseVM { IsSuccess = true, Message = "Object found", Data = viewModel });
        }
        //[HttpPost]
        protected virtual async Task<IActionResult> Create([FromForm] TVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                model = await _service.Add(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(new ResponseVM { IsSuccess = true, Message = "Object Created Successfully", Data = model });
        }
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(TKey id, [FromBody] TVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(viewModel);
            }
            var OldModel = await _service.GetById(id);
            if (OldModel == null)
            {
                return NotFound(new ResponseVM { IsSuccess = false, Message = "Not Found Object" });
            }
            viewModel.Id = id;
            await _service.Update(viewModel);
            return Ok(new ResponseVM { IsSuccess = true, Message = "Data Updated Successfully", Data = viewModel });
        }


        protected virtual async Task<IActionResult> Delete(TKey id)
        {
            var viewModel = await _service.GetById(id);
            if (viewModel == null)
            {
                return NotFound(new ResponseVM { IsSuccess = false, Message = "Not Found Object" });
            }
            await _service.Delete(viewModel);
            return Ok(new ResponseVM { IsSuccess = true, Message = "Data Deleted Successfully", Data = viewModel });
        }

        //get with include
        protected async Task<TVM> GetFirstOrDefault(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                        bool disableTracking = true,
                                        bool ignoreQueryFilters = false)
        {
            return await _service.GetFirstOrDefault(predicate, orderBy, include, disableTracking, ignoreQueryFilters);
        }
    }
}
