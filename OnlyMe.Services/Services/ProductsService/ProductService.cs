using AutoMapper;
using OnlyMe.DAL.Entities.Products;
using OnlyMe.DAL.Models.Products;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.Services.Services.ProductsService
{
    public class ProductService: BaseService<Product, ProductVM, int>, IProductService
    {
        public ProductService(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper)
        {

        }
        public override ProductVM MapEntityToModel(Product entity)
        {
            return _mapper.Map<ProductVM>(entity);
        }
        public override Product MapModelToEntity(ProductVM entity)
        {
            return _mapper.Map<Product>(entity);
        }
        protected override Func<Product, ProductVM> FuncToVM()
        {
            return c => MapEntityToModel(c);
        }
    }
}
