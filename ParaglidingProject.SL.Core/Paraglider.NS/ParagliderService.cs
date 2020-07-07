using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Flights.NS;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Helpers;
using ParaglidingProject.SL.Core.Paraglider.NS.Helpers;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Paraglider.NS
{
    /// <inheritdoc/>
    public class ParagliderService : IParagliderService
    {
        private readonly ParaglidingClubContext _paraContext;

        public ParagliderService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
        }
        public async Task<ParagliderDto> GetParagliderAsync(int id)
        {
            var paraglider = await _paraContext.Paragliders
                .AsNoTracking()
                .Select(p => new ParagliderDto
                {
                    ParagliderId = p.ID,
                    Name = p.Name,
                    CommissioningDate = p.CommissioningDate,
                    LastRevision = p.LastRevisionDate,
                    ParagliderModelId = p.ParagliderModel.ID,
                    NumerOfFlights = p.Flights.Count
                })
                .FirstOrDefaultAsync(p => p.ParagliderId == id);

            return paraglider;
        }
        public async Task<IReadOnlyCollection<ParagliderDto>> GetAllParaglidersAsync(ParaglidersSSFP options)
        {
            var paragliders = _paraContext.Paragliders
                .AsNoTracking()
                .FilterParaglidersBy(options.FilterBy, options.CommissionDate,options.LastRevisionDate, options.ParagliderModelId)
                .SearchParaglidersBy(options)
                .SortParagliderBy(options.SortBy)
                .Select(p => new ParagliderDto
                {
                    ParagliderId = p.ID,
                    Name = p.Name,
                    CommissioningDate = p.CommissioningDate,
                    LastRevision = p.LastRevisionDate,
                    ParagliderModelId = p.ParagliderModel.ID,
                    NumerOfFlights = p.Flights.Count()
                });

            options.SetPagingValues(paragliders);

            var pagedQuery = paragliders.Page(options.PageNumber - 1, options.PageSize);

            return await pagedQuery.ToListAsync();
        }

        public void CreateParaglider(ParagliderDto pParagliderDto)
        {
            _paraContext.Paragliders.Add(new Models.Paraglider
            {
                Name = pParagliderDto.Name,
                CommissioningDate = pParagliderDto.CommissioningDate,
                LastRevisionDate = pParagliderDto.LastRevision,
                IsActive = true,
                ParagliderModelID = pParagliderDto.ParagliderModelId
            });
            _paraContext.SaveChanges();
        }
        public void EditParaglider(ParagliderDto pParagliderDto)
        {
            var toModifyAsParaglider = _paraContext.Paragliders.Select(p => p).Where(pId => pId.ID == pParagliderDto.ParagliderId).FirstOrDefault();

            toModifyAsParaglider.Name = pParagliderDto.Name;
            toModifyAsParaglider.CommissioningDate = pParagliderDto.CommissioningDate;
            toModifyAsParaglider.LastRevisionDate = pParagliderDto.LastRevision;
            toModifyAsParaglider.ParagliderModelID = pParagliderDto.ParagliderModelId;

            _paraContext.Paragliders.Update(toModifyAsParaglider);
            _paraContext.SaveChanges();
        }
        public void DeleteParaglider(int pParagliderDtoId)
        {
            var toDelete = _paraContext.Paragliders.Select(p => p).Where(pId => pId.ID == pParagliderDtoId).FirstOrDefault();

            toDelete.IsActive = false;
            _paraContext.Paragliders.Update(toDelete);
            _paraContext.SaveChanges();
        }

        public async Task<IReadOnlyCollection<ParagliderDto>> GetParaglidersByModelParaglider(int id)
        {
            var paragliders = _paraContext.Paragliders.Select(p => new ParagliderDto
            {
                ParagliderId = p.ID,
                LastRevision = p.LastRevisionDate,
                CommissioningDate = p.CommissioningDate,
                Name = p.Name,
                NumerOfFlights = p.Flights.Count(),
                ParagliderModelId = p.ParagliderModelID
            }).Where(p => p.ParagliderModelId == id);

            return await paragliders.ToListAsync();
        }

        public async Task<bool?> UpdateParagliderAsync(int paragliderId, ParagliderPatchDto paragliderPatchDto)
        {
            var paragliderToUpdate = await _paraContext.Paragliders.FirstOrDefaultAsync(p => p.ID == paragliderId);

            if (paragliderToUpdate == null) return null;

            paragliderToUpdate.Name = paragliderPatchDto.Name;
            paragliderToUpdate.LastRevisionDate = paragliderPatchDto.LastRevision;

            return await _paraContext.SaveChangesAsync() > 0;

        }

        public async Task<ParagliderPatchDto> GetParagliderToPatchAsync(int paragliderId)
        {
            return await _paraContext.Paragliders
                .Where(p => p.ID == paragliderId)
                .Select(p => new ParagliderPatchDto
                {
                    Name = p.Name,
                    LastRevision = p.LastRevisionDate
                })
                .FirstOrDefaultAsync();
        }
    }
}
