using OnlyMe.DAL.Entities.Inventories;
using OnlyMe.DAL.Entities.Varieties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public int VarietyId { get; set; }
        public Variety Variety { get; set; }
        public List<Inventory> Inventories { get; set; }
        public Product():base()
        {
            Inventories = new List<Inventory>();
        }
    }
}
