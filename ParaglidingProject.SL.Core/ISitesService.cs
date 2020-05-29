using ParaglidingProject.SL.Core.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core
{
    public interface ISitesService
    {
        Task<SiteDto> GetSiteAsync(int id);
        Task<IReadOnlyCollection<SiteDto>> GetAllSitesAsync();
    }
}
