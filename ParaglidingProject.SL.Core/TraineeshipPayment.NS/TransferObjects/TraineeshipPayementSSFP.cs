using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeshipPayment.NS.TransferObjects
{
    class TraineeshipPayementSSFP
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
        public int TotalePages { get; private set; }
        public int TotalCount { get; private set; }
        public void SetPagingValue<T>(IQueryable<T> query)
        {
            TotalCount = query.Count();
            TotalPage = TotalCount / PageSize;

            if ((double)TotalCount / PageSize != 0)
            {
                TotalPage++;
            }

            if (PageNumber < 1)
                PageNumber = 1;

            if (PageNumber > TotalPage)
                PageNumber = TotalPage;

            if (PageNumber < 0)
                PageNumber = 1;
        }


    }
}
