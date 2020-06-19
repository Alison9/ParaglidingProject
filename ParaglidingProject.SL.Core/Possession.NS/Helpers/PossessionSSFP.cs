using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Possession.NS.Helpers
{
  public class PossessionSSFP
  {
    private const int DefaultPageSize = 4;
    private const int MaxPageSize = 10;

    private int _pageSize = DefaultPageSize;
    //public PossessionsFilters FilterBy { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
      get => _pageSize;
      set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public int TotalPages { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPrevious => (PageNumber > 1);
    public bool HasNext => (PageNumber < TotalPages);

    public void SetPagingValues<T>(IQueryable<T> query)
    {
      TotalCount = query.Count();
      TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
      PageNumber = Math.Min(Math.Max(1, PageNumber), TotalPages) > 0 ? Math.Min(Math.Max(1, PageNumber), TotalPages) : 1;
    }
  }
}
