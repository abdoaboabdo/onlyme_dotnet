using OnlyMe.DAL.Entities.VendorInvoices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Entities.Stores
{
    public class Store : BaseEntity<int>
    {
        [Required(ErrorMessage ="Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name{ get; set; }
        public string Address { get; set; }
        public List<VendorInvoice> VendorInvoices { get; set; }
        public Store():base()
        {
            VendorInvoices = new List<VendorInvoice>();
        }
    }
}
