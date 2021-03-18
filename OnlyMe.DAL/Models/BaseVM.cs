using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.Models
{
    public abstract class BaseVM<TKey> where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }   // create first one // Guid you put here id of user
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }  // in grid, when admin modify any thing, write modified by him  // Guid you put here id of 
        public bool IsActive { get; set; }  // default value , = false
        public bool IsDeleted { get; set; }  // default value , = false
        public BaseVM()
        {
            ModifiedOn = DateTime.Now;
            if (CreatedOn == new DateTime())
            {
                IsActive = true;
                CreatedOn = DateTime.Now;
                IsDeleted = false;
            }
        }
    }
}
