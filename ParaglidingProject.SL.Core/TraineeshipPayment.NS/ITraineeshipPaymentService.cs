using ParaglidingProject.SL.Core.TraineeshipPayement.NS.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.TraineeshipPayement.NS
{
    public interface ITraineeshipPaymentService
    {
        Task<TraineeshipPaymentDto> GetTraineeshipPaymentAsync(int id);
        Task<IReadOnlyCollection<TraineeshipPaymentDto>> GetAllTraineeshipPaymentAsync();
    }
}
