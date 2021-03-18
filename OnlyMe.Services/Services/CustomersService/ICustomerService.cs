using OnlyMe.DAL.Entities.Customers;
using OnlyMe.DAL.Models.Customers;
using OnlyMe.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.Services.Services.CustomersService
{
    public interface ICustomerService : IService<Customer, CustomerVM, int>
    {
    }
}
