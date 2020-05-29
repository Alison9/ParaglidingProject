using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Paraglider.NS
{
    public interface IParagliderService
    {
        Task<ParagliderDto> GetParagliderAsync(int id);
        Task<IReadOnlyCollection<ParagliderDto>> GetAllParaglidersAsync();
    }
}
