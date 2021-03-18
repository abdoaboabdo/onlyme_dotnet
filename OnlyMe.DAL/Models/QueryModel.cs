using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.Models
{
    public class QueryModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public string SortDirection { get; set; }
        public string SearchTerm { get; set; }

        public string Logic { get; set; }

        public QueryModel()
        {
            CurrentPage = 1;
            PageSize = 10;
            Sort = "Id";
            SortDirection = "des";
            SearchTerm = string.Empty;
            Logic = "AND";
        }
    }
}
