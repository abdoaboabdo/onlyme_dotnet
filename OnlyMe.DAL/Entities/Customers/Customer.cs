using OnlyMe.DAL.Entities.CustomerInvoices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Entities.Customers
{
    public class Customer : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string AddressDetails { get; set; }
        public List<CustomerInvoice> CustomerInvoices { get; set; }
        public Customer():base()
        {
            CustomerInvoices = new List<CustomerInvoice>();
        }
    }
}
