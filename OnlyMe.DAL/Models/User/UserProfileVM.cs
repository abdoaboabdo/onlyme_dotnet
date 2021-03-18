using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.User
{
    public class UserProfileVM
    {
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }
        public string AddressDetails { get; set; }
        [Required(ErrorMessage = "* Required")]
        public virtual string UserName { get; set; }
        [Required(ErrorMessage = "* Required")]
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Id { get; set; }
    }
}
