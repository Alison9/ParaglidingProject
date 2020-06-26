using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeshipPayment.NS.Helpers
{
   
    public static class TraineeshipPaymentSearch
    {
        public static IQueryable<Models.TraineeshipPayment> SearchTraineeshipPaymentBy(this IQueryable<Models.TraineeshipPayment> TraineeshipPayment, TraineeshipPaymentSSFP options)
        {
            if(string.IsNullOrWhiteSpace(options.UserInput))
            {
                return TraineeshipPayment;
            }

            return TraineeshipPayment
                        .Where(p => TraineeshipPayment.Any(TraineeshipPayment => p.Pilot.LastName.Contains(options.UserInput)));

        }
    }
}
