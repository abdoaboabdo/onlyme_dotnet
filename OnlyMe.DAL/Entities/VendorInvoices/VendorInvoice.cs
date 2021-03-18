using OnlyMe.DAL.Entities.Inventories;
using OnlyMe.DAL.Entities.Stores;
using OnlyMe.DAL.Entities.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlyMe.DAL.Entities.VendorInvoices
{
    public class VendorInvoice : BaseEntity<int>
    {
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public int VendorId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime DateTime { get; set; }
        public Vendor Vendor { get; set; }
        public Store Store { get; set; }
        public List<Inventory> Inventories { get; set; }
        public VendorInvoice():base()
        {
            Inventories = new List<Inventory>();
        }
    }
}
