using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }
        public string AddressDetails { get; set; }
    }
}
