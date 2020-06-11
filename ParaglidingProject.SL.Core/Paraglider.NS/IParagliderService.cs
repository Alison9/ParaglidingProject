using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Paraglider.NS
{
    /// <summary>
    ///paraglider's contract
    /// </summary>
    public interface IParagliderService
    {
        /// <summary>
        /// Async method for gettig Paraglider By id
        /// </summary>
        /// <param name="id">id is an int </param>
        /// <returns>returns ParagliderDto that contains name, CommissioningDate, LastRevision, ParagliderModelAprrovalNumber, NumerOfFlights</returns>
       
        Task<ParagliderDto> GetParagliderAsync(int id);


        /// <summary>
        /// Async method for gettig Paraglider Collection
        /// </summary>
        /// <returns>returns ReadOnlyCollection of Paragliders  </returns>
        Task<IReadOnlyCollection<ParagliderDto>> GetAllParaglidersAsync();
    }
}
