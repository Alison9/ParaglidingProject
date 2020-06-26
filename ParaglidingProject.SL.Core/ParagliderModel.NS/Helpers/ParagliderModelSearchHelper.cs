using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers
{
	public enum ParagliderModelSearchs
	{
		NoSearch = 0,
		SearchNumber = 1,
		SearchDate = 2
	}
	public static class ParagliderModelSearchHelper
	{
		public static IQueryable<Models.ParagliderModel> ParagliderModelSearchBy(this IQueryable<Models.ParagliderModel> paragliderModelSearch, ParagliderModelSearchs searchBy, string numberSearch, string dateSearch)
		{
			DateTime dateParsed = new DateTime();
			var isDateOk = DateTime.TryParse(dateSearch, out dateParsed);
			if (!isDateOk)throw new ArgumentOutOfRangeException(nameof(searchBy), searchBy, null);

			switch (searchBy)
			{
				case ParagliderModelSearchs.NoSearch:
					return paragliderModelSearch;
				case ParagliderModelSearchs.SearchNumber:
					return paragliderModelSearch.Where(pm => pm.ApprovalNumber.Contains(numberSearch));
				case ParagliderModelSearchs.SearchDate:
					return paragliderModelSearch.Where(pm => pm.ApprovalDate == dateParsed);
				default:
					throw new ArgumentOutOfRangeException(nameof(searchBy), searchBy, null);
			}
			  
		}

	}
}
