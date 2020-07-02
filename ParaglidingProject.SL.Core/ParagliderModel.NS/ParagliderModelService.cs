using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace ParaglidingProject.SL.Core.ParagliderModel.NS
{
    /// <inheritdoc/>
    public class ParagliderModelService : IParagliderModelService
    {
      private readonly Data.ParaglidingClubContext _paraContext;

      public ParagliderModelService(ParaglidingClubContext paraContext)
      {
        _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
      }
      public async Task<ParagliderModelDto> GetParagliderModelAsync(int id)
      {
        var modelparaglider = await _paraContext.ParagliderModels
            .AsNoTracking()
            .Select(p => new ParagliderModelDto
            {
              ID = p.ID,
              Size = p.Size,
              MaxWeightPilot = p.MaxWeightPilot,
              MinWeightPilot = p.MinWeightPilot,
              ApprovalDate = p.ApprovalDate,
              ApprovalNumber = p.ApprovalNumber,
              IsActive = p.IsActive

            })
            .FirstOrDefaultAsync(p => p.ID == id);

        return modelparaglider;
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
      public async Task<IReadOnlyCollection<ParagliderModelDto>> GetAllParagliderModelsAsync(ParagliderModelsSSFP options)
      {
        var modelparaglider = _paraContext.ParagliderModels //DEFERED EXECUTION
            .AsNoTracking()
            .ParagliderModelSearchBy(options.SearchBy)
            .FilterParagliderModelBy(options.FilterBy,options.Pilotweight)
            .Select(p => new ParagliderModelDto // Projection
            {
              ID = p.ID,
              Size = p.Size,
              MaxWeightPilot = p.MaxWeightPilot,
              MinWeightPilot = p.MinWeightPilot,
              ApprovalDate = p.ApprovalDate,
              ApprovalNumber = p.ApprovalNumber,
              IsActive = p.IsActive
            });

            options.SetPagingValues(modelparaglider); //Appel de la fonction située dans ParagliderModelsSSFP
            return await modelparaglider.ToListAsync(); // Flattening
      }

        public void CreateParagliderModel(ParagliderModelDto paragliderModelDto)
        {
            var temp = _paraContext.ParagliderModels.Add(new Models.ParagliderModel
            {
                Size = paragliderModelDto.Size,
                MaxWeightPilot = (int)paragliderModelDto.MaxWeightPilot,
                MinWeightPilot = (int)paragliderModelDto.MinWeightPilot,
                ApprovalNumber = paragliderModelDto.ApprovalNumber,
                ApprovalDate = paragliderModelDto.ApprovalDate,
                IsActive = true
            });
            _paraContext.SaveChanges();
        }
        public void EditParagliderModel(ParagliderModelDto pParagliderModelDto)
        {
           var toModifyAsParaglider = _paraContext.ParagliderModels.Select(p => p).Where(pId => pId.ID == pParagliderModelDto.ID).FirstOrDefault();

            toModifyAsParaglider.MaxWeightPilot = (int)pParagliderModelDto.MaxWeightPilot;
            toModifyAsParaglider.MinWeightPilot = (int)pParagliderModelDto.MinWeightPilot;
            toModifyAsParaglider.ApprovalDate = pParagliderModelDto.ApprovalDate;
            toModifyAsParaglider.ApprovalNumber = pParagliderModelDto.ApprovalNumber;
            toModifyAsParaglider.Size = pParagliderModelDto.Size;

            _paraContext.ParagliderModels.Update(toModifyAsParaglider);
            _paraContext.SaveChanges();
        }
        public void DeleteParagliderModel(int id)
        {
            var toDelete = _paraContext.ParagliderModels.Select(pm => pm).Where(pmId => pmId.ID == id).FirstOrDefault();

            toDelete.IsActive = false;

            _paraContext.ParagliderModels.Update(toDelete);
            _paraContext.SaveChanges();
        }
    }
}
