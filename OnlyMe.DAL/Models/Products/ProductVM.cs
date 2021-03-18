using OnlyMe.DAL.Models.Inventories;
using OnlyMe.DAL.Models.Varieties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlyMe.DAL.Models.Products
{
    public class ProductVM : BaseVM<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public int VarietyId { get; set; }
        public VarietyVM Variety { get; set; }
        public List<InventoryVM> Inventories { get; set; }
        public ProductVM():base()
        {
            Inventories = new List<InventoryVM>();
        }
    }
}
