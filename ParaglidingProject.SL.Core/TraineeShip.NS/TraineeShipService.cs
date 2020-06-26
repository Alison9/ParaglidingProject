using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Helpers;
using ParaglidingProject.SL.Core.TraineeShip.NS.Helpers;
using ParaglidingProject.SL.Core.TraineeShip.NS.NewFolder1;
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

        /// <summary>
        /// Get all(collection of traineeships)
        /// </summary>
        /// <param name="options"> options as traineeshipSSFP </param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<TraineeShipDto>> GetAllTraineeShipAsync(TraineeshipSSFP options)
        {
            var traineeships = _paraContext.Traineeships
                 .AsNoTracking()
                 .SortTraineeshipBy(options.SortBy)
                 .SearchTraineeshipBy(options.SearchBy)
                 .Select(T => new TraineeShipDto
                 {
                     Traineeshipid = T.ID,
                     TraineeShipStartDate=T.StartDate,
                     TraineeShipPrice=T.Price,
                     TraineeShipEndDate=T.EndDate,
                     traineeshipIsActive=T.IsActive
                 });
            options.SetPagingValues(traineeships);

            var pagedQuery = traineeships.Page(options.PageNumber -1, options.PageSize);

            return await pagedQuery.ToListAsync();
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
            int pilotMaxDiffuculty = _paraContext.Pilots.AsNoTracking()
                .Where(p => p.ID == pilotId)
                .Select(p => p.Possessions.Select(l => l.License.Level.DifficultyIndex)
                .Max())
                .FirstOrDefault();
            
            var traneeShipSortedByPilotLicense = _paraContext.Traineeships
                .AsNoTracking()
                .Where(tl => tl.License.Level.DifficultyIndex == (pilotMaxDiffuculty + 1) && tl.StartDate > DateTime.Today.AddDays(1))
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

