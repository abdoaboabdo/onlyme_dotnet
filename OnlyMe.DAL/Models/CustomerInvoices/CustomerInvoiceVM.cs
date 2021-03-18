using OnlyMe.DAL.Models.Customers;
using OnlyMe.DAL.Models.Sales;
using OnlyMe.DAL.Models.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.CustomerInvoices
{
    public class CustomerInvoiceVM :BaseVM<int>
    {
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public bool IsPaied { get; set; }
        public CustomerVM Customer { get; set; }
        public StoreVM Store { get; set; }
        public List<SaleVM> Sales { get; set; }
        public CustomerInvoiceVM() :base()
        {
            Sales = new List<SaleVM>();
        }
    }
}
