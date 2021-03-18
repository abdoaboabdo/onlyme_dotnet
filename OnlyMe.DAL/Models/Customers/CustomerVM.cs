using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.Customers
{
    public class CustomerVM : BaseVM<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string AddressDetails { get; set; }
        public CustomerVM() : base()
        {

        }
    }
}
