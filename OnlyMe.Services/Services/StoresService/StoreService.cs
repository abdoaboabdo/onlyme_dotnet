using AutoMapper;
using OnlyMe.DAL.Entities.Stores;
using OnlyMe.DAL.Models.Stores;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.Services.Services.StoresService
{
    public class StoreService : BaseService<Store, StoreVM, int>, IStoreService
    {
        public StoreService(IRepository<Store, int> repository, IMapper mapper):base(repository,mapper)
        {
        }
        public override StoreVM MapEntityToModel(Store entity)
        {
            return _mapper.Map<StoreVM>(entity);
        }
        public override Store MapModelToEntity(StoreVM entity)
        {
            return _mapper.Map<Store>(entity);
        }
        protected override Func<Store, StoreVM> FuncToVM()
        {
            return c => MapEntityToModel(c);
        }
    }
}
