using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Utilities
{
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;
        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 產生 Jwt Token
        /// </summary>
        /// <param name="id">使用者Id</param>
        /// <param name="account">使用者帳號</param>
        /// <returns></returns>
        public string GenerateJwtToken(int id, string account)
        {
            var issuer = _configuration.GetValue<string>("Jwt:issuer");
            var key = _configuration.GetValue<string>("Jwt:key");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, account),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", id.ToString()),
                new Claim("role", "Admin")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer, null, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(30), credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
