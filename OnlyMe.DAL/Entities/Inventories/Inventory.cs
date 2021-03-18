using OnlyMe.DAL.Entities.Products;
using OnlyMe.DAL.Entities.Sales;
using OnlyMe.DAL.Entities.VendorInvoices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Entities.Inventories
{
    public class Inventory : BaseEntity<int>
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
        public Product Product { get; set; }
        public VendorInvoice Invoice { get; set; }
        public List<Sale> Sales { get; set; }
        public Inventory():base()
        {
            Sales = new List<Sale>();
        }
    }
}
