using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.TraineeShip.NS
{
     public class TraineeShipService : ITraineeShipService
    {
        private readonly ParaglidingClubContext _paraContext;
        public TraineeShipService(ParaglidingClubContext paraContext)
        {
            this._paraContext = paraContext;
        }
        public async Task<IReadOnlyCollection<TraineeShipDto>> GetAllTraineeShipAsync()
        {
            var traineeships = _paraContext.Traineeships
                 .AsNoTracking()
                 .Select(T => new TraineeShipDto
                 {
                     Traineeshipid = T.ID,
                     TraineeShipStartDate=T.StartDate,
                     TraineeShipPrice=T.Price,
                     TraineeShipEndDate=T.EndDate,
                     traineeshipIsActive=T.IsActive
                 });

            return await traineeships.ToListAsync();
        }



        public async Task<TraineeShipDto> GetTraineeShipAsync(int id)
        {
            var traineeship = await _paraContext.Traineeships
              .AsNoTracking()
              .Select(t => new TraineeShipDto
              {
                  Traineeshipid= t.ID,
                  TraineeShipStartDate=t.StartDate,
                  TraineeShipPrice=t.Price,
                  TraineeShipEndDate=t.EndDate,
                  traineeshipIsActive=t.IsActive
              })
              .FirstOrDefaultAsync(p => p.Traineeshipid == id);

            //var pilotDto = pilot.MapPilotDto();

            return traineeship;
        }
        public async Task<IReadOnlyCollection<TraineeShipSortByPilotLicenseDto>> GetAllTraineeShipSortedByPilotLicense(int pilotId)
        {
            int pilotLicenseid = _paraContext.Pilots.AsNoTracking().Where(p => p.ID == pilotId).Select(p => p.Possessions.Select(l => l.LicenseID).Max()).FirstOrDefault();
            
            var traneeShipSortedByPilotLicense = _paraContext.Traineeships
                .AsNoTracking()
                .Where(tl => tl.LicenseID == (pilotLicenseid + 1) && tl.StartDate > DateTime.Today)
                .Select(t => new TraineeShipSortByPilotLicenseDto
                {
                    LicenseId = t.LicenseID,
                    LicenseTitle = t.License.Title,
                    traineeShipId = t.ID
                });
            return await traneeShipSortedByPilotLicense.ToListAsync();
        }

        public async Task<IReadOnlyCollection<TraineeShipDto>> GetTraineeshipsByPilotAsync(int pilotId)
        {
            var traineeships = _paraContext.Traineeships
                  .AsNoTracking()
                  .Include(t => t.TraineeshipPayments)  
                  .Where(t => t.TraineeshipPayments.Any(tp => tp.PilotID == pilotId))
                  .Select(T => new TraineeShipDto
                  {
                      Traineeshipid = T.ID,
                      TraineeShipStartDate = T.StartDate,
                      TraineeShipPrice = T.Price,
                      TraineeShipEndDate = T.EndDate,
                      traineeshipIsActive = T.IsActive
                  });

            return await traineeships.ToListAsync();
        }
    }
}

