using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers
{
    public static class ParagliderModelSearchHelper
	{
		public static IQueryable<Models.ParagliderModel> ParagliderModelSearchBy(this IQueryable<Models.ParagliderModel> paragliderModels, string searchBy)
		{
            if (string.IsNullOrWhiteSpace(searchBy))
            {
                return paragliderModels;
            }

            if (searchBy.Contains("m²"))
            {
                var sanitizedSearchBy = searchBy.Substring(0, 2);
                var sizeParsed = int.TryParse(sanitizedSearchBy, out var searchBySize);

                if (sizeParsed)
                    return paragliderModels.Where(pm => pm.Size.Contains(searchBySize.ToString()));
            }

            var dateParsed = DateTime.TryParse(searchBy, out var searchByDate);

            if (dateParsed)
                return paragliderModels.Where(pm => pm.ApprovalDate == searchByDate);

            if (searchBy.Length == 8 && searchBy.Contains("/"))
                return paragliderModels.Where(pm => pm.ApprovalNumber == searchBy);

            throw new AmbiguousActionException("Search does not make any sense");
        }
    }
}
