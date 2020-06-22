using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Helpers;
using ParaglidingProject.SL.Core.Possession.NS.Helpers;
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

        /// <inheritdoc />
        public async Task<PossessionDto> GetPossessionAsync(int pilotId,int licenseId)
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
                .FirstOrDefaultAsync(po => po.PilotID == pilotId && po.LicenseID == licenseId);
            
            return possession;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<PossessionDto>> GetAllPossessionsAsync(PossessionSSFP options)
        {
            var possessions = _paraContext.Possessions
                .AsNoTracking()
                .FilterPossessionBy(options)
                .Select(po => new PossessionDto
                {
                   
                    PilotID = po.PilotID,
                    LicenseID = po.LicenseID,
                    ExamDate = po.ExamDate,
                    IsSucceeded = po.IsSucceeded,
                    IsActive = po.IsActive
                });

            

         options.SetPagingValues(possessions);

         var pagedQuery = possessions.Page(options.PageNumber - 1, options.PageSize); // PAGINATION

         return await pagedQuery.ToListAsync();
    }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<PossessionDto>> GetPossessionByPilotAsync(int pilotId)
        {
            var pilot = await _paraContext.Pilots
               .AsNoTracking()              
               .FirstOrDefaultAsync(p => p.ID == pilotId);

            if (pilot == null) return null;

            var possessions = _paraContext.Possessions
                .AsNoTracking()
                .Where(po => po.PilotID == pilotId)
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

