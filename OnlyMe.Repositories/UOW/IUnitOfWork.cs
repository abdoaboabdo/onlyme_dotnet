using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMe.Repository.UOW
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
