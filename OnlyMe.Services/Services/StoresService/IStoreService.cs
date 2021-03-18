using OnlyMe.DAL.Entities.Stores;
using OnlyMe.DAL.Models.Stores;
using OnlyMe.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.Services.Services.StoresService
{
    public interface IStoreService : IService<Store, StoreVM, int>
    {
    }
}
