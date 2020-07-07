using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.Helpers
{ 
    public enum TraineeshipFilters
    {
       NoFilter=0,
       past=1,
       future=2,
       present=3
    }
    public static class TraineeshipFilterHelper
    {


        public static IQueryable<Models.Traineeship> FilterTraineeshipBy(this IQueryable<Models.Traineeship> traineeships, TraineeshipFilters filterBy)
        {
            
            switch (filterBy)
            {
                case TraineeshipFilters.NoFilter:
                    return traineeships;

                case TraineeshipFilters.present:
                    return traineeships
                         .Where(t => t.StartDate <= DateTime.Today)
                         .Where(t => t.EndDate >= DateTime.Today);
                         
                         
                case TraineeshipFilters.future:
                    return traineeships
                        .Where(t => t.StartDate > DateTime.Today);
                case TraineeshipFilters.past:
                    return traineeships
                        .Where(t => t.EndDate<= DateTime.Today);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }


        }

    }
}
