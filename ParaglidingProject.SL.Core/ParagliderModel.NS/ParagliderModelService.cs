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

      public async Task<IReadOnlyCollection<ParagliderModelDto>> GetAllParagliderModelsAsync(ParagliderModelsSSFP options)
      {
            var modelparaglider = _paraContext.ParagliderModels //DEFERED EXECUTION
                .AsNoTracking()
                .ParagliderModelSearchBy(options.SearchBy, pSize: options.Size,pApprovalNumber: options.ApprovalNumber)
            .ParagliderModelsSortsBy(options.SortsBy)
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
        public async Task<bool?> EditParagliderModel(int paragliderId,ParagliderModelPatchDto pParagliderPatch)
        {
           var toModifyAsParaglider = _paraContext.ParagliderModels.Select(p => p).Where(pId => pId.ID == paragliderId).FirstOrDefault();

            toModifyAsParaglider.MaxWeightPilot = (int)pParagliderPatch.MaxWeightPilot;
            toModifyAsParaglider.MinWeightPilot = (int)pParagliderPatch.MinWeightPilot;

            return await _paraContext.SaveChangesAsync() > 0;
        }
        public async Task<ParagliderModelPatchDto> GetParagliderModelToPatchAsync(int pParagliderId)
        {
            return await _paraContext.ParagliderModels
                .Where(pm => pm.ID == pParagliderId)
                .Select(pm => new ParagliderModelPatchDto
                {
                    MaxWeightPilot = pm.MaxWeightPilot,
                    MinWeightPilot = pm.MinWeightPilot
                }).FirstOrDefaultAsync();
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
