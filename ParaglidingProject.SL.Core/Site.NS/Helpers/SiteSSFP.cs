using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.Helpers
{
    public class SiteSSFP
    {
        public string SiteName { get; set; }
        public string SiteApproach { get; set; }
        public int AltitudeTakeOff { get; set; }
        public string Orientation { get; set; }
        //Pagination  
        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        private SitesFilters _filterBy;
        public SitesSorts SortBy { get; set; }
        public SitesFilters FilterBy
        {
            get => _filterBy;
            set => _filterBy = ValidetaFilterByParametres(value) ? value : 0;
        }
        public SitesSearchingBy SearchBy
        { 
            get => searchBy; 
            set => searchBy = ValidateSearchByParameters(value) ? value : 0; 
        }
        private int _pageSize = DefaultPageSize;
        private SitesSearchingBy searchBy;

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

            PageNumber = NormalizePageNumber();
        }
        private bool ValidateSearchByParameters(SitesSearchingBy paraSearch)
        {
            switch (paraSearch)
            {
                case SitesSearchingBy.None:
                    return true;
                case SitesSearchingBy.ApproachManeuver:
                    {
                        if (!string.IsNullOrWhiteSpace(SiteApproach))
                        {
                            return true;
                        }
                        return false;
                    }
                case SitesSearchingBy.Name:
                    {
                        if (!string.IsNullOrWhiteSpace(SiteName))
                        {
                            return true;
                        }
                        return false;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool ValidetaFilterByParametres(SitesFilters paragfilter)
        {
            switch (paragfilter)
            {
                case SitesFilters.NoFilter:
                    return true;
                case SitesFilters.NotActive:
                    return true;
                case SitesFilters.Orientation:
                    if (!string.IsNullOrEmpty(Orientation))
                    {
                        return true;
                    }
                    return false;
                case SitesFilters.Altitude:
                    return true;
                default:
                    return false;
            }
        }
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
