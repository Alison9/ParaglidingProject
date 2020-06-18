using ParaglidingProject.SL.Core.Auth.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Auth.NS
{
    public interface IAuthService
    {
        Task<bool?> Authenticate(CredentialsParams credentials);

        TokenDto GenerateJwt(string firstname, string lastname, string secret);

        public UserInfoDto ObtainUserIdentity(ClaimsPrincipal user);
    }
}
