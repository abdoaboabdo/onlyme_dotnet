using Microsoft.EntityFrameworkCore.Query;
using OnlyMe.DAL;
using OnlyMe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMe.Repository.Interfaces
{
    public interface IRepository<T, TKey>
        where T : BaseEntity<TKey>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        Task<List<T>> ListAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IPagedResult<T, TVM, TKey> GetPagedResult<TVM>(QueryModel queryModel, Func<T, TVM> func, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where TVM : BaseVM<TKey>;

        Task<T> GetFirstOrDefault(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>,
            IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false);
        Task<List<T>> GetTOList(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                        bool disableTracking = true,
                                        bool ignoreQueryFilters = false);
    }
}
