using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Site.NS
{
    public interface ISitesService
    {
        Task<SiteDto> GetSiteAsync(int id);
        Task<IReadOnlyCollection<SiteDto>> GetAllSitesAsync();
    }
}
