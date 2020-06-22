using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.MapperProfiles;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS
{
    /// <inheritdoc/>
    public class PilotsService : IPilotsService
    {
        private readonly ParaglidingClubContext _paraContext;
        private readonly IMapper _mapperProfile;

        public PilotsService(ParaglidingClubContext paraContext, IMapper mapperProfile)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
            _mapperProfile = mapperProfile;
        }

        public async Task<PilotDto> GetPilotAsync(int id)
        {
            var pilot = await _paraContext.Pilots
                .AsNoTracking()
                .Include(p => p.Flights)
                .FirstOrDefaultAsync(p => p.ID == id);

            var pilotDto = pilot?.MapPilotDto();

            return pilotDto;
        }

        public async Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync(SSFP options)
        {
            var pilotsQuery = _paraContext.Pilots // DEFERRED EXECUTION
                .AsNoTracking()
                .FilterPilotBy(options.FilterBy) // RESTRICTION = WHERE
                .ProjectTo<PilotDto>(_mapperProfile.ConfigurationProvider);
                //.Select(p => new PilotDto // PROJECTION = SELECT
                //{
                //    PilotId = p.ID,
                //    Name = $"{p.FirstName} {p.LastName}",
                //    Address = p.Address,
                //    NumberOfFlights = p.Flights.Count
                //});

            options.SetPagingValues(pilotsQuery);

            var pagedQuery = pilotsQuery.Page(options.PageNumber - 1, options.PageSize); // PAGINATION

            return await pagedQuery.ToListAsync(); // FLATTENING = ITERATION 
        }

        public async Task<bool?> UpdatePilotAsync(int pilotId, PilotPatchDto patchDto)
        {
            var pilotToUpdate = await _paraContext.Pilots
                .FirstOrDefaultAsync(p => p.ID == pilotId);

            if (pilotToUpdate == null) return null;

            pilotToUpdate.PhoneNumber = patchDto.PhoneNumber;
            pilotToUpdate.Weight = patchDto.Weight;

            return await _paraContext.SaveChangesAsync() > 0;
        }

        public async Task<PilotPatchDto> GetPilotToPatchAsync(int pilotId)
        {
            return await _paraContext.Pilots
                .Where(p => p.ID == pilotId)
                .Select(p => new PilotPatchDto
                {
                    PhoneNumber = p.PhoneNumber,
                    Weight = p.Weight
                })
                .FirstOrDefaultAsync();
        }
    }
}