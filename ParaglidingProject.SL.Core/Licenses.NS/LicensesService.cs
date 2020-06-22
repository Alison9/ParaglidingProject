using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Licenses.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Licenses.NS
{
    public class LicensesService : ILicensesService
    {
        private readonly ParaglidingClubContext _paraContext;

        public LicensesService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentOutOfRangeException(nameof(paraContext));
        }
        /// <inheritdoc />
        public async Task<LicenseDto> GetLicenseAsync(int id)
        {
            var license = await _paraContext.Licenses
                .AsNoTracking()
                .Select(l => new LicenseDto
                {
                    LicenseID = l.ID,
                    Title = l.Title,
                    LevelDifficultyIndex = l.Level.DifficultyIndex
                })
                .FirstOrDefaultAsync(l => l.LicenseID == id);

            return license;
        }
    }
}
