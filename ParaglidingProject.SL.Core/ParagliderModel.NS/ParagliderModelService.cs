using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

  }
}
