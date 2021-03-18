using OnlyMe.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMe.Repository.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlyMeDBContext _dBContext;

        public UnitOfWork(OnlyMeDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task Save()
        {
            await _dBContext.SaveChangesAsync();
        }
    }
}
