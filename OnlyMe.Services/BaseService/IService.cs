using Microsoft.EntityFrameworkCore.Query;
using OnlyMe.DAL;
using OnlyMe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMe.Services.BaseService
{
    public interface IService<T, TVM, TKey>
        where T : BaseEntity<TKey>
        where TVM : BaseVM<TKey>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        Task<TVM> GetById(TKey id);
        Task<List<TVM>> GetAll();
        Task<TVM> Add(TVM viewModel);
        Task Update(TVM viewModel);
        Task Delete(TVM viewModel);
        IPagedResult<T, TVM, TKey> GetPagedResult(QueryModel queryModel, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<TVM> GetFirstOrDefault(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                        bool disableTracking = true,
                                        bool ignoreQueryFilters = false);
        Task<List<TVM>> GetTOList(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                        bool disableTracking = true,
                                        bool ignoreQueryFilters = false);
    }
}
