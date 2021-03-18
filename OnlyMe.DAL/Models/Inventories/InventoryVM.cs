using OnlyMe.DAL.Models.Products;
using OnlyMe.DAL.Models.Sales;
using OnlyMe.DAL.Models.VendorInvoices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.Inventories
{
    public class InventoryVM:BaseVM<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int InvoiceId { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Purchasingprice { get; set; }
        public decimal? ExpectedSellingPrice { get; set; }
        public ProductVM Product { get; set; }
        public VendorInvoiceVM Invoice { get; set; }
        public List<SaleVM> Sales { get; set; }
        public InventoryVM():base()
        {
            Sales = new List<SaleVM>();
        }
    }
}
