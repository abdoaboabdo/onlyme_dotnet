using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.Roles
{
    public class CreateRoleVM
    {
        [Required(ErrorMessage = "مطلوب ادخال الوظيفة")]
        public string RoleName { get; set; }
    }
}
