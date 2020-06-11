using System.Collections.Generic;
using System.Threading.Tasks;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS
{ 
   
    public interface IPilotsService
    {
       
        Task<PilotDto> GetPilotAsync(int id);
        
       
        Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync();
    }
}
