using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ParaglidingProject.SL.Core.Auth.NS;
using ParaglidingProject.SL.Core.Auth.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
        /// <summary>
        /// Return a Token for an authorized member. Asynchronous ActionResult
        /// </summary>
        /// <param name="credentials">Informations for verification</param>   
        /// <response code="200">Member authorized</response>
        /// <response code="401">Person unauthorized</response>
		    /// <response code="404">Person not found</response>
			  /// seealso cref="authDto" 
    [Authorize]
    [Route("api/v1/auth")]
    [ApiExplorerSettings(GroupName ="authentification")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IAuthService _authService;

        public AuthController(IOptions<AppSettings> appSettings, IAuthService authService)
        {
            _appSettings = appSettings.Value;
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> GetToken([FromBody] CredentialsParams credentials)
        {
            //Authenticate

            var isKnow = await _authService.Authenticate(credentials);
            if (isKnow == null) return NotFound("User not found");
            if ((bool) !isKnow) return Unauthorized("Wrong user");

            var myTokenDto = _authService.GenerateJwt(credentials.FirstName, credentials.LastName, _appSettings.Secret) ;
            if (myTokenDto.Token == null) return Unauthorized("Something went wrong");

            return Ok(myTokenDto);

        }

    }
}
