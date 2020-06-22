using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.Helpers
{
    public class SiteSSFP
    {
        private const int DefaultPageSize = 1;
        private int _pageSize = DefaultPageSize;
        private const int MaxPageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public bool HasPrevious => (PageNumber > 1);
        public bool HasNext => (PageNumber < TotalPages);
                                                                   
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
     

        public void SetPagingValues<T>(IQueryable<T> query)
        {
            TotalCount = query.Count();
            TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
            if (PageNumber > 0)
                PageNumber = PageNumber > TotalPages ? TotalPages : PageNumber;
            else
                PageNumber = 1;
        }
    }
}
