using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.User
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "ادخل اسم المستخدم")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "ادخل الرقم السرى")]
        public string Password { get; set; }
    }
}
