using OnlyMe.DAL.Models.Categories;
using OnlyMe.DAL.Models.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Models.Varieties
{
    public class VarietyVM : BaseVM<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }
        public CategoryVM Category { get; set; }
        public List<ProductVM> Products { get; set; }
        public VarietyVM() : base()
        {
            Products = new List<ProductVM>();
        }
    }
}
