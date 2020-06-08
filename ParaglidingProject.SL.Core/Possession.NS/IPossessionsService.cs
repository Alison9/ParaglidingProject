using ParaglidingProject.SL.Core.Possession.NS.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Possession.NS
{
   public interface IPossessionsService 
    {
        Task<PossessionDto> GetPossessionAsync(int Pilotid,int Licenseid);
        Task<IReadOnlyCollection<PossessionDto>> GetAllPossessionsAsync();
        Task<IReadOnlyCollection<PossessionDto>> GetPossessionByPilotAsync(int pPilotId);
    }
}
