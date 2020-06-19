using ParaglidingProject.SL.Core.TraineeshipPayement.NS.TransferObjects;
using ParaglidingProject.SL.Core.TraineeshipPayment.NS.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.TraineeshipPayement.NS
{
    
   /// <summary>
  /// TraineeShip payment contract
  /// </summary>
    public interface ITraineeshipPaymentService
    {
        /// <summary>
        /// Get TraineeShip Payment By PilotID AND TraineeShipId
        /// </summary>
        /// <param name="pilotId"> pilotid identified pilot int  </param>
        /// <param name="traineeshipId"> identified trainee ship int </param>
        /// <returns> traineeship payment Dto contains some properties
        /// <seealso cref="TraineeshipPaymentDto"/>
        /// </returns>
        Task<TraineeshipPaymentDto> GetTraineeshipPaymentAsync(int pilotId, int traineeshipId);
        /// <summary>
        /// Get All (Collection of TrainshipPayments)
        /// </summary>
        /// <param name="options">options as TraineeshipPaymentSSFP</param>
        /// <returns> return  collection TraineeShip PaymentsDto
        /// <seealso cref="TraineeshipPaymentDto"/>
        /// </returns>
      
        Task<IReadOnlyCollection<TraineeshipPaymentDto>> GetAllTraineeshipPaymentAsync(TraineeshipPaymentSSFP options);
    }
}
