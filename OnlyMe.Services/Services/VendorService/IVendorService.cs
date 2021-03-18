using OnlyMe.DAL.Entities.Vendors;
using OnlyMe.DAL.Models.Vendors;
using OnlyMe.Services.BaseService;

namespace OnlyMe.Services.Services.VendorService
{
    public interface IVendorService : IService<Vendor,VendorVM,int>
    {
    }
}
