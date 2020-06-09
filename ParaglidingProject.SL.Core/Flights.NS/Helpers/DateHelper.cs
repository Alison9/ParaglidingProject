using System;
using System.Collections.Generic;
using System.Text;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Flights.NS.Helpers
{
    public static class DateHelper
    {
        public static bool ValidateDate(this DateRangeParams dates)
        {
            var beginDate = DateTime.Parse(dates.BeginDate);
            var endDate = DateTime.Parse(dates.EndDate);

            if (endDate < beginDate)
            {
                return false;
            }

            return true;
        }
    }
}
