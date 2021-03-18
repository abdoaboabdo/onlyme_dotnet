using AutoMapper;
using OnlyMe.DAL.Entities.Customers;
using OnlyMe.DAL.Models.Customers;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.Services.Services.CustomersService
{
    public class CustomerService : BaseService<Customer, CustomerVM,int>, ICustomerService
    {
        public CustomerService(IRepository<Customer,int> repository, IMapper mapper) :base(repository, mapper)
        {

        }
        public override CustomerVM MapEntityToModel(Customer entity)
        {
            return _mapper.Map<CustomerVM>(entity);
        }
        public override Customer MapModelToEntity(CustomerVM entity)
        {
            return _mapper.Map<Customer>(entity);
        }
        protected override Func<Customer, CustomerVM> FuncToVM()
        {
            return c => MapEntityToModel(c);
        }
    }
}
