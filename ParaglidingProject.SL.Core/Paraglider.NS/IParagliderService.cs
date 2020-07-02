using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Paraglider.NS.Helpers;
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
        /// The task result contains null by default if source is empty or if no element passes the test specified by predicate.
        /// Otherwise, the task result is a ParagliderDto with several properties.
        /// <seealso cref="ParagliderDto"/>
        Task<ParagliderDto> GetParagliderAsync(int id);


        /// <summary>
        /// Async method for gettig Paraglider Collection
        /// </summary>
        /// <param name="options">User options to search, sort, filter and paginate a list of paragliders</param>
        /// <returns>returns ReadOnlyCollection of Paragliders  </returns>
        Task<IReadOnlyCollection<ParagliderDto>> GetAllParaglidersAsync(ParaglidersSSFP options);

        void CreateParaglider(ParagliderDto paragliderDto);
        void EditParaglider(ParagliderDto paragliderDto);
        void DeleteParaglider(int paragliderDtoId);
        Task<IReadOnlyCollection<FlightDto>> GetFlightsByParaglider(int id);
    }
}
