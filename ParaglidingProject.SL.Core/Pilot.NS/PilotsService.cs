using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.MapperProfiles;
using ParaglidingProject.SL.Core.TransfertObjects;

namespace ParaglidingProject.SL.Core
{
    public class PilotsService : IPilotsService
    {
        private readonly ParaglidingClubContext _paraContext;

        public PilotsService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
        }

        public async Task<PilotDto> GetPilotAsync(int id)
        {
            var pilot = await _paraContext.Pilots
                .AsNoTracking()
                .Include(p => p.Flights)
                .FirstOrDefaultAsync(p => p.ID == id);

            var pilotDto = pilot.MapPilotDto();

            return pilotDto;
        }

        public async Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync()
        {
            var pilots = _paraContext.Pilots
                .AsNoTracking()
                .Select(p => new PilotDto
                {
                    PilotId = p.ID,
                    Name = $"{p.FirstName} {p.LastName}",
                    Address = p.Address,
                    NumberOfFlights = p.Flights.Count
                });

            return await pilots.ToListAsync();
        }
    }
}