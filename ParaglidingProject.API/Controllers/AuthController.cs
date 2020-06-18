using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ParaglidingProject.SL.Core.Auth.NS;
using ParaglidingProject.SL.Core.Auth.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "authentication")]
    [Produces("application/json")]
    [Route("api/v1/auth")] 
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
        [Consumes("application/json")]
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> GetToken([FromBody] CredentialsParams credentials)
        {
            // Authenticate
            var isKnown = await _authService.Authenticate(credentials);
            if (isKnown == null) return NotFound("Pilot does not exist");
            if ((bool) !isKnown) return Unauthorized("Wrong credentials");

            // Generate token if Auth was successful
            var token = _authService.GenerateJwt(credentials.FirstName, _appSettings.Secret);
            if (token.Token == null) return Unauthorized("Something went wrong");

            return Ok(token);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("me")]
        public ActionResult<UserInfoDto> GetRequesterInfos()
        {
            var userInfos = _authService.ExtractInfo(User);
            if (userInfos == null) return NotFound();
            return userInfos;
        }
    }
}