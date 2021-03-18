using OnlyMe.DAL.Entities.Categories;
using OnlyMe.DAL.Entities.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Entities.Varieties
{
    public class Variety : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products{ get; set; }
        public Variety() :base()
        {
            Products = new List<Product>(); 
        }
    }
}
