using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS
{
    /// <summary>
    /// Paraglider model's contract
    /// </summary>
  public interface IParagliderModelService
  {
        /// <summary>
        /// Get a paraglider model
        /// </summary>
        /// <param name="ID">Paraglider model's ID</param>
        /// <returns> A paraglider model</returns>
    Task<ParagliderModelDto> GetParagliderModelAsync(int ID);

        /// <summary>
        /// Get all paraglider models
        /// </summary>
        /// <returns>A collection of paraglider models</returns>
    Task<IReadOnlyCollection<ParagliderModelDto>> GetAllParagliderModelsAsync();
  }
}

