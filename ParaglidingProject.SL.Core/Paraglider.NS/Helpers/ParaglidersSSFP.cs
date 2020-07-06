using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static ParaglidingProject.SL.Core.Paraglider.NS.Helpers.ParagliderSortHelper;

namespace ParaglidingProject.SL.Core.Paraglider.NS.Helpers
{
    public class ParaglidersSSFP
    {
      
        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        private ParaglidersFilters _filterBy;

        public string CommissionDate { get; set; }
        public string LastRevisionDate { get; set; }
        public int ParagliderModelId { get; set; }
        public ParagliderSort SortBy { get; set; }

        public ParaglidersFilters FilterBy 
        { 
            get => _filterBy;
            set => _filterBy = ValidateFilterByParameters(value)? value: 0; 
        }
        private int _pageSize = DefaultPageSize;
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

        //Search propreties
        public ParaglidersSearch SearchBy { get; set; }
        public string Name { get; set; }
        public DateTime DateLastRevision { get; set; }

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
        public bool ValidateFilterByParameters(ParaglidersFilters paraglidersFilters)
        {
            DateTime parsedDate;
            switch (paraglidersFilters)
            {
                case ParaglidersFilters.NoFilter:
                    return true;
                case ParaglidersFilters.NotActive:
                    return true;
                case ParaglidersFilters.CommissionDate:
                    if (!string.IsNullOrWhiteSpace(CommissionDate) && DateTime.TryParse(CommissionDate, out parsedDate))
                    {
                        return true;
                    }
                    return false;
                case ParaglidersFilters.RevisionDate:
                    if (!string.IsNullOrWhiteSpace(LastRevisionDate) && DateTime.TryParse(LastRevisionDate, out parsedDate))
                    {
                        return true;
                    }
                    return false;
                case ParaglidersFilters.ModelParaglider:
                    return true;
                default:
                    return false;
            }
        }
    }
}
