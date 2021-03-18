using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlyMe.DAL
{
    public class BaseEntity<TKey> where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        public BaseEntity(/*دلوقتى Login اليوزر اللى inject ممكن هنا تعمل*/)
        {
            ModifiedOn = DateTime.Now;
            if (CreatedOn == new DateTime())
            {
                IsActive = true;
                CreatedOn = DateTime.Now;
                IsDeleted = false;
            }
        }
        public TKey Id { get; set; }
        [Column(Order = 100)]
        public DateTime CreatedOn { get; set; }
        [Column(Order = 101)]
        public Guid CreatedBy { get; set; }   // create first one // Guid you put here id of user
        [Column(Order = 102)]
        public DateTime ModifiedOn { get; set; }
        [Column(Order = 103)]
        public Guid ModifiedBy { get; set; }  // in grid, when admin modify any thing, write modified by him  // Guid you put here id of 
        public bool IsActive { get; set; }  // default value , = false
        public bool IsDeleted { get; set; }  // default value , = false
    }
}
