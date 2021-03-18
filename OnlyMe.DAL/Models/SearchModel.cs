using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.Models
{
    public class SearchModel
    {
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
