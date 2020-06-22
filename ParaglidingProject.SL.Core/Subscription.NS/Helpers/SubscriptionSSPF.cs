using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Subscription.NS.Helpers
{
    public class SubscriptionSSPF
    {
        private const int DefaultPageSize = 1;
        private const int MaxPageSize = 10;

        private int _pageSize = DefaultPageSize;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; 
        }
        public int TotalPages { get; private set; }
        public int TotalAmountSubscriptions { get; set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => (PageNumber > 1);
        public bool HasNext => (PageNumber < TotalPages);

        public SubscriptionFilters filterBy { get; set; }
        /// <summary>
        /// Refactoring method that sets the correct page number for the user that navigates a collection of subscriptions.
        /// If the user tries to go below the first page or over the last page, it is redirected to the first page or the last page, respectively. 
        /// </summary>
        /// <returns>
        /// An integer with the correct page number.
        /// </returns>
        public void SetPagingValues<T>(IQueryable<T> query)
        {
            TotalCount = query.Count();
            TotalPages=(int)Math.Ceiling((double)TotalCount / PageSize);

            if (Math.Min(Math.Max(1,PageNumber),TotalPages) > 0)
            {
                PageNumber = Math.Min(Math.Max(1, PageNumber), TotalPages);
            }
            else
            {
                PageNumber = 1;
            }
        }
        public decimal AmountTrigger { get; set; }
        public SubscriptionSorts orderBy { get; set; }

    }
}
