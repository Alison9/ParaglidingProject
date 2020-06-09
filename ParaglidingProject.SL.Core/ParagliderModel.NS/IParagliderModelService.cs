using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS
{
  public interface IParagliderModelService
  {
    Task<ParagliderModelDto> GetParagliderModelAsync(int ID);
    Task<IReadOnlyCollection<ParagliderModelDto>> GetAllParagliderModelsAsync();
  }
}

