using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Possession.NS.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Possession.NS
{
   public class PossessionsService : IPossessionsService
    {
        private readonly ParaglidingClubContext _paraContext;

        public PossessionsService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentOutOfRangeException(nameof(paraContext));
        }

        public async Task<PossessionDto> GetPossessionAsync(int Pilotid,int Licenseid)
        {
            var possession = await _paraContext.Possessions
                .AsNoTracking()
                .Select(po => new PossessionDto
                {

                    PilotID = po.PilotID,
                    LicenseID = po.LicenseID,
                    ExamDate = po.ExamDate,
                    IsSucceeded = po.IsSucceeded,
                    IsActive = po.IsActive
                })
                .FirstOrDefaultAsync(po => po.PilotID == Pilotid && po.LicenseID == Licenseid);
            
            return possession;
        }
        public async Task<IReadOnlyCollection<PossessionDto>> GetAllPossessionsAsync()
        {
            var possessions = _paraContext.Possessions
                .AsNoTracking()
                .Select(po => new PossessionDto
                {
                   
                    PilotID = po.PilotID,
                    LicenseID = po.LicenseID,
                    ExamDate = po.ExamDate,
                    IsSucceeded = po.IsSucceeded,
                    IsActive = po.IsActive
                });

            return await possessions.ToListAsync();
        }
        public async Task<IReadOnlyCollection<PossessionDto>> GetPossessionByPilotAsync(int PilotId)
        {
            var possessions = _paraContext.Possessions
                .AsNoTracking()
                .Where(po => po.PilotID == PilotId)
                .Select(po => new PossessionDto
                {

                    PilotID = po.PilotID,
                    LicenseID = po.LicenseID,
                    ExamDate = po.ExamDate,
                    IsSucceeded = po.IsSucceeded,
                    IsActive = po.IsActive
                });

            return await possessions.ToListAsync();
        }
    }
}

