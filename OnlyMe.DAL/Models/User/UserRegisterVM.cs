using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.User
{
    public class UserRegisterVM
    {
        public virtual string Id { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Required")]
        public virtual string PhoneNumber { get; set; }
        [Required(ErrorMessage = "* Required")]
        public virtual string UserName { get; set; }
        [Required(ErrorMessage = "* Required")]
        public virtual string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "الرقم السرى مطلوب")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "تأكيد الرقم السرى غير مطابق للرقم السرى")]
        [Required(ErrorMessage = "تأكيد الرقم السرى مطلوب")]
        public string ConfirmPassword { get; set; }
    }
}
