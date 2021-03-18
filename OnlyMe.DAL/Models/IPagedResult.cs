using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.Models
{
    public interface IPagedResult<T, TVM, TKey>
       where T : BaseEntity<TKey>
       where TVM : BaseVM<TKey>
       where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        int TotalElements { get; set; }
        int TotalPages { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        int Pages { get; set; }
        IEnumerable<TVM> Result { get; set; }
    }
}
