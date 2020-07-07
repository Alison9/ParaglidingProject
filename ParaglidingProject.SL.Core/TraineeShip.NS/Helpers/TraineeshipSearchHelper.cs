using ParaglidingProject.SL.Core.TraineeShip.NS.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.Helpers
{
    public enum TraineeshipSearchs
    {
        NoSearch = 0,
        License = 1,
        Price = 2
    }
    public static class TraineeshipSearchHelper
    {
        public static IQueryable<Models.Traineeship> SearchTraineeshipBy(this IQueryable<Models.Traineeship> traineeships, TraineeshipSSFP options)
        {

            switch (options.SearchBy)
            {
                case TraineeshipSearchs.NoSearch:
                    return traineeships;

                case TraineeshipSearchs.License:
                    return traineeships
                         .Where(t => t.License.Title.Contains(options.License));

                case TraineeshipSearchs.Price:
                    return traineeships
                        .Where(t => t.Price.ToString().Contains(options.Price));

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(options.SearchBy), options.SearchBy, null);
            }


        }
    }
}
