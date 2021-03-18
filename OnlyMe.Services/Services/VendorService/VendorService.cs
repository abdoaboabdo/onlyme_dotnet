using AutoMapper;
using OnlyMe.DAL.Entities.Vendors;
using OnlyMe.DAL.Models.Vendors;
using OnlyMe.Repository.Interfaces;
using OnlyMe.Services.BaseService;
using System;

namespace OnlyMe.Services.Services.VendorService
{
    public class VendorService : BaseService<Vendor, VendorVM, int>, IVendorService
    {
        public VendorService(IRepository<Vendor, int> repository, IMapper mapper):base(repository, mapper)
        {

        }
        public override VendorVM MapEntityToModel(Vendor entity)
        {
            return _mapper.Map<VendorVM>(entity);
        }
        public override Vendor MapModelToEntity(VendorVM entity)
        {
            return _mapper.Map<Vendor>(entity);
        }
        protected override Func<Vendor, VendorVM> FuncToVM()
        {
            return c => MapEntityToModel(c);
        }

    }
}
