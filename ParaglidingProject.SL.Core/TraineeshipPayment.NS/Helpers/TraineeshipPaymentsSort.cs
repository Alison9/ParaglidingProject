using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeshipPayment.NS.Helpers
{
    public enum TraineeShipPaymentSorts
    {
        NoFilter = 0,
        byDate = 1,
        bypilotid = 2


    }


    public static class TraineeshipPaymentSort
    {
        /// <summary>
        /// A static method that sorts a query of traineeshippayment given by the user.
        /// </summary>
        /// <param name="raineeshippayments">A query of traineeshippayment to sort</param>
        /// <param name="sortBy">>One of the sort available in a list (enum) of possibilities.</param>
        /// <returns>
        /// A custom-sorted query respecting the user's requests if the sort exist.
        /// An exception if a sort does not exist.</returns>
        public static IQueryable<Models.TraineeshipPayment> SortTraineeshipPaymentBy(this IQueryable<Models.TraineeshipPayment> traineeshippayments, TraineeShipPaymentSorts sortBy)
        {
            switch (sortBy)
            {

                case TraineeShipPaymentSorts.NoFilter:
                    return traineeshippayments;

                case TraineeShipPaymentSorts.byDate:

                    return traineeshippayments.OrderBy(t => t.PaymentDate);

                case TraineeShipPaymentSorts.bypilotid:

                    return traineeshippayments.OrderByDescending(t => t.PilotID);


                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(sortBy), sortBy, null);


            }
        }

    }
}
