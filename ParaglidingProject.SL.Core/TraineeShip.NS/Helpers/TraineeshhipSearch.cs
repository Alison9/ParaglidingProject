using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.Helpers
{ 
    public enum TraineeShipSearch
    {
       NoSearch=0,
       past=1,
       future=2,
        present=3
    }
    public static class TraineeshhipSearch
    {


        public static IQueryable<Models.Traineeship> SearchTraineeshipBy(this IQueryable<Models.Traineeship> traineeships, TraineeShipSearch searchBy)
        {
            
            switch (searchBy)
            {
                case TraineeShipSearch.NoSearch:
                    return traineeships;

                case TraineeShipSearch.present:
                    return traineeships
                         .Where(t => t.StartDate <= DateTime.Today)
                         .Where(t => t.EndDate >= DateTime.Today);
                         
                         
                case TraineeShipSearch.future:
                    return traineeships
                        .Where(t => t.StartDate > DateTime.Today);
                case TraineeShipSearch.past:
                    return traineeships
                        .Where(t => t.EndDate<= DateTime.Today);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(searchBy), searchBy, null);
            }


        }

    }
}
