using AutoMapper;
using OnlyMe.DAL.Entities.Customers;
using OnlyMe.DAL.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyMe.API.MapperConfig.MapperProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, Customer>();
        }
    }
}
