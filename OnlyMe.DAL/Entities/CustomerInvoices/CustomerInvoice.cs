using OnlyMe.DAL.Entities.Customers;
using OnlyMe.DAL.Entities.Sales;
using OnlyMe.DAL.Entities.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Entities.CustomerInvoices
{
    public class CustomerInvoice : BaseEntity<int>
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
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
