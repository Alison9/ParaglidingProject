using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeshipPayment.NS.Helpers
{
    /// <summary>
    /// Search, Sort, Filter, Page
    /// </summary>
    public class TraineeshipPaymentSSFP
    {
        private const int DefaultPageSize = 2;
        private const int MaxPageSize = 10;

        private int _pageSize = DefaultPageSize;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set { 
                
                if (value > MaxPageSize)
                {
                    _pageSize = MaxPageSize;
                }
                else
                {
                    _pageSize = value;
                }
            
            } 
        }
        public string UserInput { get; set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => (PageNumber > 1);
        public bool HasNext => (PageNumber < TotalPages);
        public void SetPagingValues<T>(IQueryable<T> query)
        {
            TotalCount = query.Count();

            TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);

            //if (Math.Min(Math.Max(1, PageNumber), TotalPages) > 0)
            //{
            //    PageNumber = Math.Min(Math.Max(1, PageNumber), TotalPages);
            //}
            //else
            //{
            //    PageNumber = 1;
            //}

          PageNumber = NormalizePageNumber();

        }

        private int NormalizePageNumber()
        {
            int normalizedPageNumber;

            // Premier essai de if

            //if (PageNumber <= 0)
            //{
            //    normalizedPageNumber = 1;
            //}
            //else if (PageNumber > TotalPages)
            //{
            //    normalizedPageNumber = TotalPages;
            //}
            //else
            //{
            //    normalizedPageNumber = PageNumber;
            //}

            //Deuxième essai de if

            if(PageNumber >0)
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
