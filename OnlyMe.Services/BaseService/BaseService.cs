using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using OnlyMe.DAL;
using OnlyMe.DAL.Models;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMe.Services.BaseService
{
    public abstract class BaseService<T, TVM, TKey> : IService<T, TVM, TKey>
        where T : BaseEntity<TKey>
        where TVM : BaseVM<TKey>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        protected readonly IRepository<T, TKey> _repository;
        protected readonly IMapper _mapper;
        public abstract TVM MapEntityToModel(T entity);
        public abstract T MapModelToEntity(TVM model);
        protected abstract Func<T, TVM> FuncToVM();

        public BaseService(IRepository<T, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TVM> Add(TVM viewModel)
        {
            var model = _mapper.Map<TVM, T>(viewModel);
            model = await _repository.AddAsync(model);
            return _mapper.Map<T, TVM>(model);
        }

        public async Task Delete(TVM viewModel)
        {
            var model = _mapper.Map<TVM, T>(viewModel);
            await _repository.DeleteAsync(model);
        }

        public async Task<List<TVM>> GetAll()
        {
            var list = await _repository.ListAsync();
            return _mapper.Map<List<T>, List<TVM>>(list);
        }

        public async Task<TVM> GetById(TKey id)
        {
            return _mapper.Map<T, TVM>(await _repository.GetByIdAsync(id));
        }

        public async Task Update(TVM viewModel)
        {
            var model = _mapper.Map<TVM, T>(viewModel);
            await _repository.UpdateAsync(model);
        }


        public IPagedResult<T, TVM, TKey> GetPagedResult(QueryModel queryModel, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return _repository.GetPagedResult(queryModel, FuncToVM(), include);
        }
        //get with include


        public async Task<TVM> GetFirstOrDefault(Expression<Func<T, bool>> predicate ,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy ,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
                                        bool disableTracking ,
                                        bool ignoreQueryFilters )
        {
            return _mapper.Map<T, TVM>(await _repository.GetFirstOrDefault(predicate, orderBy, include, disableTracking, ignoreQueryFilters));
        }

        public async Task<List<TVM>> GetTOList(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true, 
            bool ignoreQueryFilters = false
            )
        {
            return _mapper.Map<List<T>, List<TVM>>(await _repository.GetTOList(predicate, orderBy, include, disableTracking, ignoreQueryFilters));
        }
    }
}
