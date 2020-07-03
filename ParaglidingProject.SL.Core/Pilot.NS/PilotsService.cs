using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS
{
    /// <inheritdoc/>
    public class PilotsService : IPilotsService
    {
        private readonly ParaglidingClubContext _paraContext;
        private readonly ILogger<PilotsService> _logger;

        public PilotsService(ParaglidingClubContext paraContext, ILogger<PilotsService> logger)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
            _logger = logger;
        }

        public async Task<PilotDto> GetPilotAsync(int id)
        {
            var pilot = await _paraContext.Pilots
                .AsNoTracking()
                .Include(p => p.Flights)
                .Include(p => p.Possessions)
                .ThenInclude(po => po.License)
                .Include(p => p.TraineeshipPayments)
                .ThenInclude(tp => tp.Traineeship)
                .Include(p => p.PilotTraineeships)
                .ThenInclude(pt => pt.Traineeship)
                .Select(p => new PilotDto
                {
                    PilotId = p.ID,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Address = p.Address,
                    PhoneNumber = p.PhoneNumber,
                    Weight = p.Weight,
                    IsActive = p.IsActive,
                    Role = p.Role,
                    NumberOfFlights = p.Flights.Count,
                    TotalFlightHours = p.Flights.Sum(f => f.Duration),
                    Flights = p.Flights,
                    Possessions = p.Possessions,
                    TraineeshipPayments = p.TraineeshipPayments,
                    PilotTraineeships = p.PilotTraineeships
                })
                .FirstOrDefaultAsync(p => p.PilotId == id);

            _logger.LogInformation("TEST TEST TEST TEST TEST TEST TEST");

            //var pilotDto = pilot?.MapPilotDto();

            return pilot;
        }

        public async Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync(PilotSSFP options)
        {
            var pilotsQuery = _paraContext.Pilots // DEFERRED EXECUTION
                .AsNoTracking()
                .SearchPilotBy(options)
                .SortPilotsBy(options.SortBy)
                .FilterPilotBy(options.FilterBy, options.LicenseID) // RESTRICTION = WHERE
                .Select(p => new PilotDto // PROJECTION = SELECT
                {
                    PilotId = p.ID,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Address = p.Address,
                    PhoneNumber = p.PhoneNumber,
                    Weight = p.Weight,
                    IsActive = p.IsActive,
                    NumberOfFlights = p.Flights.Count
                });

            options.SetPagingValues(pilotsQuery);

            var pagedQuery = pilotsQuery.Page<PilotDto>(options.PageNumber - 1, options.PageSize); // PAGINATION

            return await pagedQuery.ToListAsync(); // FLATTENING = ITERATION 
        }

        public async Task PostPilotAsync(Models.Pilot pilot)
        {
            if (pilot == null)
            {
                throw new ArgumentNullException();
            }

            _paraContext.Pilots.Add(pilot);
            await _paraContext.SaveChangesAsync();
        }

        public async Task UpdatePilotAsync(Models.Pilot pilot)
        {
            _paraContext.Entry(pilot).State = EntityState.Modified;
            await _paraContext.SaveChangesAsync();
        }

        public async Task DeletePilotAsync(int? id)
        {
            if (id == null )
            {
                throw new ArgumentNullException("Id not found.");
            }

            var pilot = _paraContext.Pilots
                .Where(p => p.ID == id)
                .FirstOrDefault();

            if (pilot == null)
            {
                throw new ArgumentNullException("Pilot not found.");
            }

            pilot.IsActive = false;
            _paraContext.Entry(pilot).State = EntityState.Modified;
            await _paraContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<PilotDto>> GetPilotsByTraineeship(int id)
        {
            var pilots = _paraContext.Pilots
            .Where(p => p.TraineeshipPayments.Any(tp => tp.TraineeshipID == id))
            .Select(p => new PilotDto
             {
                 PilotId = p.ID,
                 FirstName = p.FirstName,
                 LastName = p.LastName,
                 Address = p.Address,
                 PhoneNumber = p.PhoneNumber,
                 Weight = p.Weight,
                 IsActive = p.IsActive,
                 NumberOfFlights = p.Flights.Count

             });

            return await pilots.ToListAsync();
        }
    }
}