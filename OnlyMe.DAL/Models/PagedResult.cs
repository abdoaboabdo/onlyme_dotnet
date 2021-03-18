using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlyMe.DAL.Models
{
    public class PagedResult<T, TVM, TKey> : IPagedResult<T, TVM, TKey>
        where T : BaseEntity<TKey>
        where TVM : BaseVM<TKey>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
        public IEnumerable<TVM> Result { get; set; }

        public PagedResult(IQueryable<T> queryable, int page, int size, Func<T, TVM> func)
        {
            TotalElements = queryable.Count();
            CurrentPage = page;
            PageSize = size;
            TotalPages = TotalElements / PageSize;

            if (TotalElements % PageSize > 0)
                TotalPages++;
            if (size > 0)
                Pages = (int)Math.Ceiling((decimal)TotalElements / (decimal)size);
            if (Pages == 0 && TotalElements > 0)
                Pages = 1;
            Result = queryable.Skip((page - 1) * size).Take(size).Select(func).ToList();

        }
    }
}
