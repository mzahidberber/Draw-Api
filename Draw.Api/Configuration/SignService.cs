using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Draw.Api.Configuration
{
    public class SignService
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
