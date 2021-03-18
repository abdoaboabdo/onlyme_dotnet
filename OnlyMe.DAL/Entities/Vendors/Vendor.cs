using OnlyMe.DAL.Entities.VendorInvoices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Entities.Vendors
{
    public class Vendor : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressDetails { get; set; }
        public List<VendorInvoice> Invoices { get; set; }
        public Vendor():base()
        {
            Invoices = new List<VendorInvoice>();
        }
    }
}
