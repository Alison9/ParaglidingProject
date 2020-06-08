﻿using Microsoft.EntityFrameworkCore;
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

    }
    }
