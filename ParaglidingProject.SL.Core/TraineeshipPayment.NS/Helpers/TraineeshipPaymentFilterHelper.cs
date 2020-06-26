using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeshipPayment.NS.Helpers
{
    public enum TraineeshipPaymentsFilters
    { 
        NoFilter = 0,
        Traineeship = 1,
        Pilot = 2
    }
    public static class TraineeshipPaymentFilterHelper
    {
        public static IQueryable<Models.TraineeshipPayment> FilterTraineeshipPaymentBy(this IQueryable<Models.TraineeshipPayment> pilots, TraineeshipPaymentsFilters filterBy, TraineeshipPaymentSSFP options)
        {
            switch (filterBy)
            {
                case TraineeshipPaymentsFilters.NoFilter:
                    return pilots;

                case TraineeshipPaymentsFilters.Traineeship:
                    return pilots
                        .Where(tp => tp.TraineeshipID == options.TraineeshipId);

                case TraineeshipPaymentsFilters.Pilot:
                    return pilots
                        .Where(tp => tp.PilotID == options.PilotId);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }
    }
}