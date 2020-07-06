using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Paraglider.NS.Helpers
{
    public enum ParaglidersSearch
    {
        NoSearch = 0,
        Name = 1,
        LastRevisionDate = 2
    }
    public static class ParaglidersSearchHelper
    {
        public static IQueryable<Models.Paraglider> SearchParaglidersBy(this IQueryable<Models.Paraglider> paragliders, ParaglidersSSFP options )
        {
            switch(options.SearchBy)
            {
                case ParaglidersSearch.NoSearch:
                    return paragliders;

                case ParaglidersSearch.Name:
                    return paragliders.Where(p => p.Name.Contains(options.Name));

                case ParaglidersSearch.LastRevisionDate:
                   return paragliders.Where(p => p.LastRevisionDate <= options.DateLastRevision.AddYears(-1));

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(options.SearchBy), options.SearchBy, null);
            }
        }
    }
}
