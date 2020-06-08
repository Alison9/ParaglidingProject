using ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.TraineeShip.NS
{
  public  interface ITraineeShipService
    {
        Task<TraineeShipDto> GetTraineeShipAsync(int id);
        Task<IReadOnlyCollection<TraineeShipDto>> GetAllTraineeShipAsync();
    }
}
