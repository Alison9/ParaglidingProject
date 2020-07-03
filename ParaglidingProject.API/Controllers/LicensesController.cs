using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Licenses.NS;
using ParaglidingProject.SL.Core.Licenses.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "licenses")]
    [Produces("application/json")]
    [Route("api/v1/licenses/")]
    public class LicensesController : ControllerBase
    {
        private readonly ILicensesService _licenseService;


        public LicensesController(ILicensesService licenseService)
        {
            _licenseService = licenseService ?? throw new ArgumentNullException(nameof(licenseService));
            
        }

        [HttpGet("", Name = "GetAllLicensesAsync")]
        public async Task<ActionResult<IReadOnlyCollection<LicenseDto>>> GetAllLicenses()
        {
            var licenses = await _licenseService.GetAllLicensesAsync();
            if (licenses == null) return NotFound("Collection was empty :O");
            return Ok(licenses);
        }
    }
}