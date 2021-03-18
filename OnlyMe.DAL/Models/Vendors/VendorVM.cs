using OnlyMe.DAL.Models.VendorInvoices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Models.Vendors
{
    public class VendorVM : BaseVM<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressDetails { get; set; }
        public List<VendorInvoiceVM> Invoices { get; set; }
        public VendorVM() : base()
        {
            Invoices = new List<VendorInvoiceVM>();
        }
    }
}
