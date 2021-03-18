using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnlyMe.DAL;
using OnlyMe.DAL.Context;
using OnlyMe.DAL.Helpers;
using OnlyMe.DAL.Models;
using OnlyMe.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlyMe.Repository.Repositories
{
    public class EfRepository<T, TKey> : IRepository<T, TKey>
        where T : BaseEntity<TKey>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        private readonly OnlyMeDBContext _dbContext;
        private DbSet<T> _entities;
        public IQueryable<T> Table => Entities;

        public EfRepository(OnlyMeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _dbContext.Set<T>();
                }
                return _entities;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            var Tentity = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return Tentity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(t => t.Id.Equals(id) && t.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync() //
        {
            return await _dbContext.Set<T>().Where(t => t.IsDeleted == false).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public IPagedResult<T, TVM, TKey> GetPagedResult<TVM>(QueryModel queryModel, Func<T, TVM> func, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where TVM : BaseVM<TKey>
        {
            var queraleObj = QEntities(false);

            if (include != null && queryModel.SearchTerm.IsEmptyOrNull())
                queraleObj = include(queraleObj);

            if (queryModel.SearchTerm != null)
                queryModel.SearchTerm = queryModel.SearchTerm.Trim();

            if (!queryModel.SearchTerm.IsEmptyOrNull())
                queraleObj = ApplySearch(queraleObj, queryModel, include);

            if (!queryModel.Sort.IsEmptyOrNull())
                queraleObj = ApplySort(queraleObj, queryModel,null);

            return new PagedResult<T, TVM, TKey>(queraleObj.Where(x=>x.IsDeleted==false), queryModel.CurrentPage, queryModel.PageSize, func);
        }
        private IQueryable<T> ApplySearch(IQueryable<T> queraleObj, QueryModel queryModel, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (queraleObj is null)
                throw new ArgumentNullException(nameof(queraleObj));

            int lines = 0;

            var mapping = ((DbContext)_dbContext).Model.FindEntityType(typeof(T));
            var tableName = mapping.GetTableName();

            var searchConditions = queryModel.SearchTerm.Split(',').ToList();
            searchConditions.Add("isDeleted:0");

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"SELECT * FROM {tableName} WHERE ");


            foreach (var item in searchConditions)
            {
                var kvPair = item.Split(':');
                var pi = typeof(T).GetProperty(kvPair[0].ToFirstUpper());

                if (lines > 0)
                    stringBuilder.Append(" " + ( lines+1 != searchConditions.Count ? queryModel.Logic : "AND") + " "); 

                if (pi.PropertyType == typeof(int) )
                {
                    int n;

                    if (int.TryParse(kvPair[1],out n))
                    {
                        stringBuilder.Append($"{kvPair[0]} = {kvPair[1]}");
                    }
                    else
                    {
                        stringBuilder.Append($"{kvPair[0]} = 0");
                    }
                }  
                else if (pi.PropertyType == typeof(bool))
                    stringBuilder.Append($"{kvPair[0]} = {kvPair[1]}");
                else if (pi.PropertyType == typeof(DateTime))
                    stringBuilder.Append($"cast ([{kvPair[0]}] as date) = '{kvPair[1]}'");
                else 
                {
                    if (Regex.IsMatch(kvPair[1], @"\p{IsArabic}"))
                    {
                        stringBuilder.Append($"{kvPair[0]} LIKE N'%{kvPair[1]}%'");
                    }
                    else
                    {
                        stringBuilder.Append($"{kvPair[0]} LIKE '%{kvPair[1]}%'");
                    }
                }
                    

                lines++;
            }

            return  include == null ? _dbContext.Set<T>().FromSqlRaw(stringBuilder.ToString()).AsNoTracking() : include(_dbContext.Set<T>().FromSqlRaw(stringBuilder.ToString()).AsNoTracking());

        }
        private IQueryable<T> ApplySort(IQueryable<T> queraleObj, QueryModel queryModel, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            queryModel.Sort = queryModel.Sort.ToFirstUpper();
            var pi = typeof(T).GetProperty(queryModel.Sort);
            if (pi != null)
            {

                return queryModel.SortDirection == "des" ?
                    include == null ? queraleObj.AsEnumerable().OrderByDescending(x => pi.GetValue(x)).AsQueryable() : include(queraleObj.AsEnumerable().OrderByDescending(x => pi.GetValue(x)).AsQueryable())
                                :
                                include==null ? queraleObj.AsEnumerable().OrderBy(x => pi.GetValue(x)).AsQueryable():include(queraleObj.AsEnumerable().OrderBy(x => pi.GetValue(x)).AsQueryable());
            }
            var query = include == null ? queraleObj.OrderByDescending(x => x.Id).AsQueryable() : include(queraleObj.OrderByDescending(x => x.Id).AsQueryable());
            return query;
        }
        protected IQueryable<T> QEntities(bool track = true)
        {
            return track ? Entities : Entities.AsNoTracking();
        }


        #region get with include GetFirstOrDefault
        public virtual async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                        bool disableTracking = true,
                                        bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = Entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).Where(x => x.IsDeleted == false).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Where(x => x.IsDeleted == false).FirstOrDefaultAsync();
            }
        }
        #endregion

        #region Get With Include GetTOList
        public virtual async Task<List<T>> GetTOList(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                        bool disableTracking = true,
                                        bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = Entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).Where(x => x.IsDeleted == false).ToListAsync();
            }
            else
            {
                return await query.Where(x => x.IsDeleted == false).ToListAsync();
            }
        } 
        #endregion

    }
}
