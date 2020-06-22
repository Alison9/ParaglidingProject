using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.Helpers
{
    public enum TraineeShipSorts
    {
        NoFilter = 0,
        Price = 1,
        StartDate =2,
        EndDate=3
       
      
    }
   

    public static  class TraineeshipSort
    {
        /// <summary>
     /// A static method that sorts a query of traineeship given by the user.
     /// </summary>
     /// <param name="traineeships">A query of traineeships to sort</param>
     /// <param name="sortBy">>One of the sort available in a list (enum) of possibilities.</param>
     /// <returns>
     /// A custom-sorted query respecting the user's requests if the sort exist.
     /// An exception if a sort does not exist.</returns>
        public static IQueryable<Models.Traineeship> SortTraineeshipBy(this IQueryable<Models.Traineeship> traineeships,TraineeShipSorts sortBy )
        {
            switch (sortBy)
            {
                case TraineeShipSorts.NoFilter:
                    return traineeships;

                case TraineeShipSorts.Price:
                    return traineeships.OrderBy(t => t.Price);

                case TraineeShipSorts.StartDate:
                    return traineeships.OrderBy(t=>t.StartDate);

                case TraineeShipSorts.EndDate:
                    return traineeships.OrderBy(t => t.EndDate);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(sortBy), sortBy, null);


            }
        }

    
    }
}
