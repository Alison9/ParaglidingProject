using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Paraglider.NS.Helpers
{
    public static  class ParagliderSortHelper
    {
        public enum ParagliderSort
        {
            NoSort = 0,
            CommissionDate = 1,
            RevisionDate = 2,
            ModelParaglider = 3,
            Name=4


        }
       
            public static IQueryable<Models.Paraglider> SortParagliderBy(this IQueryable<Models.Paraglider> paragliders, ParagliderSort sortBy)
            {
                switch (sortBy)
                {
                    case ParagliderSort.NoSort:
                        return paragliders;
                    case ParagliderSort.CommissionDate:
                        return paragliders
                                     .OrderBy(p => p.CommissioningDate)
                                     .ThenBy(p => p.Name);

                    case ParagliderSort.RevisionDate:
                        return paragliders.OrderBy(p => p.LastRevisionDate);

                    case ParagliderSort.ModelParaglider:
                        return paragliders.OrderBy(p => p.ParagliderModel);

                case ParagliderSort.Name:
                    return paragliders.OrderBy(p => p.Name);


                default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }



