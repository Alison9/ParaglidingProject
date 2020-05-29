using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Paraglider.NS
{
    public interface IParagliderService
    {
        Task<ParagliderDto> GetParagliderAsync(int id);
        Task<IReadOnlyCollection<ParagliderDto>> GetAllParaglidersAsync();
    }
}
