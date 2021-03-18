using OnlyMe.DAL.Entities.Products;
using OnlyMe.DAL.Models.Products;
using OnlyMe.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.Services.Services.ProductsService
{
    public interface IProductService : IService<Product, ProductVM, int>
    {
    }
}
