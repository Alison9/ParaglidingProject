using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Paraglider.NS
{
    public class ParagliderService : IParagliderService
    {
        private readonly ParaglidingClubContext _paraContext;

        public ParagliderService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
        }
        public async Task<ParagliderDto> GetParagliderAsync(int id)
        {
            // Select Loading (inline mapping)
            var paraglider = await _paraContext.Paragliders
                .AsNoTracking()
                .Select(p => new ParagliderDto
                {
                    ParagliderId = p.ID,
                    Name = p.Name,
                    CommissioningDate = p.CommissioningDate,
                    LastRevision = p.LastRevisionDate,
                    ParagliderModelAprrovalNumber = p.ParagliderModel.ApprovalNumber,
                    NumerOfFlights = p.Flights.Count()
                })
                .FirstOrDefaultAsync(p => p.ParagliderId == id);

            //var pilotDto = pilot.MapPilotDto();

            return paraglider;
        }
        public async Task<IReadOnlyCollection<ParagliderDto>> GetAllParaglidersAsync()
        {
            var paraglider = _paraContext.Paragliders
                .AsNoTracking()
                .Select(p => new ParagliderDto
                {
                    ParagliderId = p.ID,
                    Name = p.Name,
                    CommissioningDate = p.CommissioningDate,
                    LastRevision = p.LastRevisionDate,
                    ParagliderModelAprrovalNumber = p.ParagliderModel.ApprovalNumber,
                    NumerOfFlights = p.Flights.Count()
                });

            return await paraglider.ToListAsync();
        }
    }
}
