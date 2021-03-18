using OnlyMe.DAL.Entities.CustomerInvoices;
using OnlyMe.DAL.Entities.Inventories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyMe.DAL.Entities.Sales
{
    public class Sale
    {
        [Key]
        [ForeignKey("Inventory")]
        [Column(Order = 1)]
        public int InventoryId { get; set; }
        [Key]
        [ForeignKey("CustomerInvoice")]
        [Column(Order = 2)]
        public int CustomerInvoiceId { get; set; }
        public decimal ProductSellingPrice { get; set; }
        public Inventory Inventory { get; set; }
        public CustomerInvoice CustomerInvoice { get; set; }
    }
}
