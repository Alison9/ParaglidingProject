using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers
{
    public enum ParagliderModelSearch
    {
        None = 0,
        ApprovalNumber = 1,
        Size = 2
    }
    public static class ParagliderModelSearchHelper
	{
		public static IQueryable<Models.ParagliderModel> ParagliderModelSearchBy(this IQueryable<Models.ParagliderModel> paragliderModels, 
            ParagliderModelSearch searchBy, string pApprovalNumber = null, string pSize = null)
		{
            switch(searchBy)
            {
                case ParagliderModelSearch.None:
                    return paragliderModels;
                case ParagliderModelSearch.ApprovalNumber:
                    return paragliderModels.Where(pa => pa.ApprovalNumber.Contains(pApprovalNumber));
                case ParagliderModelSearch.Size:
                    return paragliderModels.Where(s => s.Size.Contains(pSize));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
