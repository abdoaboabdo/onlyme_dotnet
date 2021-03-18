using OnlyMe.DAL.Models.Varieties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.Categories
{
    public class CategoryVM : BaseVM<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public List<VarietyVM> Variety { get; set; }
        public CategoryVM() : base()
        {
            Variety = new List<VarietyVM>();
        }
    }
}
