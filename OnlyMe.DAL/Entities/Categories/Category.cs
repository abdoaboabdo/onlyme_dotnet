using OnlyMe.DAL.Entities.Varieties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlyMe.DAL.Entities.Categories
{
    public class Category : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public List<Variety> Variety { get; set; }
        public Category():base()
        {
            Variety = new List<Variety>();
        }
    }
}
