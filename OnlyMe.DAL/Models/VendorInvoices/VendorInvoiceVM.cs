using OnlyMe.DAL.Entities.Stores;
using OnlyMe.DAL.Entities.Vendors;
using OnlyMe.DAL.Models.Inventories;
using OnlyMe.DAL.Models.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Models.VendorInvoices
{
    public class VendorInvoiceVM : BaseVM<int>
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
        public List<InventoryVM> Inventories { get; set; }

        public VendorInvoiceVM() : base()
        {
            Inventories = new List<InventoryVM>();
        }
    }
}
