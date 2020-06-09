using System.Security.Claims;
using System.Threading.Tasks;
using ParaglidingProject.SL.Core.Auth.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Auth.NS
{
    public interface IAuthService
    {
        Task<bool?> Authenticate(CredentialsParams credentials);
        TokenDto GenerateJwt(string name, string secret);
        UserInfoDto ExtractInfo(ClaimsPrincipal user);
    }
}
