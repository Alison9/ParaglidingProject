using ParaglidingProject.SL.Core.Possession.NS.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using ParaglidingProject.Models;
using System.Linq;

namespace ParaglidingProject.SL.Core.Possession.NS.MapperProfiles
{
     public static class PossessionMapping
    {
        public static IQueryable<PossessionDto> MapPossessionDto(this IQueryable<Models.Possession> Possession)
        {

            return Possession.Select(po => new PossessionDto
            {
                
                PilotID = po.PilotID,
                LicenseID = po.LicenseID,
                ExamDate = po.ExamDate,
                IsSucceeded = po.IsSucceeded,
                IsActive = po.IsActive
            });

        }
    }
}
