using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Pilot.NS.Helpers
{
    /// <summary>
    /// Search, Sort, Filter, Page
    /// </summary>
    public class PilotSSFP
    {
        private const int DefaultPageSize = 10; 
        private const int MaxPageSize = 10;

        private int _pageSize = DefaultPageSize;
        public PilotsFilters FilterBy { get; set; }
        public PilotsSorts SortBy { get; set; }
        public PilotsSearches SearchBy { get; set; }
        public string UserInput { get; set; }
        public int LicenseID { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => (PageNumber > 1);
        public bool HasNext => (PageNumber < TotalPages);
        public void SetPagingValues<T>(IQueryable<T> query)
        {
            TotalCount = query.Count();
            TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
            PageNumber = Math.Min(Math.Max(1, PageNumber), TotalPages) > 0 ? Math.Min(Math.Max(1, PageNumber), TotalPages) : 1;
        }
    }
}
