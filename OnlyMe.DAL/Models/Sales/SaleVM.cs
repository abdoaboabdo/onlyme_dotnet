using OnlyMe.DAL.Models.CustomerInvoices;
using OnlyMe.DAL.Models.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.Models.Sales
{
    public class SaleVM:BaseVM<int>
    {
        public int InventoryId { get; set; }
        public int CustomerInvoiceId { get; set; }
        public decimal ProductSellingPrice { get; set; }
        public InventoryVM Inventory { get; set; }
        public CustomerInvoiceVM CustomerInvoice { get; set; }
        public SaleVM():base()
        {

        }
    }
}
