using OnlyMe.DAL.Models.VendorInvoices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Models.Stores
{
    public class StoreVM : BaseVM<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public string Address { get; set; }
        public List<VendorInvoiceVM> VendorInvoiceVMs { get; set; }

        public StoreVM() : base()
        {
            VendorInvoiceVMs = new List<VendorInvoiceVM>();
        }
    }
}
