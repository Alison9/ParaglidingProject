using ParaglidingProject.SL.Core.Pilot.NS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Flights.NS.Helpers
{
    /// <summary>
    /// Search, Sort,Filter,Page
    /// </summary>
    public class FlightsSSFP
    {
        private const int DefaultPageSize = 10;
        private const int MaxPageSize = 10;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = DefaultPageSize;

        public int ParagliderId { get; set; }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => (PageNumber > 1);
        public bool HasNext => (PageNumber < TotalPages);
        public void SetPagingValues<T> (IQueryable<T> query)
        {
            TotalCount = query.Count();

            TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);

            PageNumber = NormalizePageNumber();
                
        }
        //Filter properties
        public FlightsFilters FilterBy { get; set; }
        public int TakeOffSiteId { get; set; }
       
        public int LandingSiteId { get; set; }

        //Sort properties
        public FlightsSorts SortBy { get; set; }

        /// <summary>
        /// Refactoring method that sets the correct page number for the user that navigates a collection of paragliders.
        /// If the user tries to go below the first page or over the last page, it is redirected to the first page or the last page, respectively. 
        /// </summary>
        /// <returns>
        /// An integer with the correct page number.
        /// </returns>
        private int NormalizePageNumber()
        {
            int normalizedPageNumber;
            if (PageNumber > 0)
            {
                normalizedPageNumber = PageNumber > TotalPages ? TotalPages : PageNumber;
            }
            else
            {
                normalizedPageNumber = 1;
            }
            return normalizedPageNumber;
        }
    }
}
