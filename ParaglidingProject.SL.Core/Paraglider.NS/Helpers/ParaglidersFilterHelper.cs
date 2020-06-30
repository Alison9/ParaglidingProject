using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Paraglider.NS.Helpers
{
    public enum ParaglidersFilters
    {
        NoFilter = 0,
        NotActive = 1,
        CommissionDate = 2,
        RevisionDate = 3,
        ModelParaglider = 4
    }
    public static class ParaglidersFilterHelper
    {
        public static IQueryable<Models.Paraglider> FilterParaglidersBy(this IQueryable<Models.Paraglider> paragliders,ParaglidersFilters filterBy,string pCommissionDate = null,string pLatRevisionDate = null, int pParagliderModelId = 0)
        {
            switch(filterBy)
            {
                case ParaglidersFilters.NoFilter:
                    return paragliders;
                case ParaglidersFilters.NotActive:
                    return paragliders.IgnoreQueryFilters().Where(pa => pa.IsActive == false);
                case ParaglidersFilters.CommissionDate:
                {
                    return paragliders = paragliders.Where(pc => pc.CommissioningDate > DateTime.Parse(pCommissionDate));
                }
                case ParaglidersFilters.RevisionDate:
                {
                    return paragliders = paragliders.Where(plr => plr.LastRevisionDate > DateTime.Parse(pLatRevisionDate));
                }
                case ParaglidersFilters.ModelParaglider:
                {
                    return paragliders = paragliders.Where(pm => pm.ParagliderModel.ID == pParagliderModelId);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            } 
        }
    }
}
