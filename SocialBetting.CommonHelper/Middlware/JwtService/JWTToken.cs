using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.CommonHelper.Middlware.JwtService
{
    public class JWTToken
    {
        public string GenerateToken(string userId, string email, IConfiguration _configuration, double? expireHours = null)
        {
            DateTime currentTime = DateTime.UtcNow;

            DateTime expirationTime = expireHours.HasValue
                ? currentTime.AddHours(expireHours.Value)
                : currentTime.AddYears(1);
            

            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration.GetValue<string>("Jwt:Subject")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Sid, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("TimeClaim", formattedTime)
            };

            var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var httpContextAccessor = new HttpContextAccessor();
            if (httpContextAccessor.HttpContext != null)
            {
                httpContextAccessor.HttpContext.User = principal;
            }

            var token = new JwtSecurityToken(
                _configuration.GetValue<string>("Jwt:Issuer"),
                _configuration.GetValue<string>("Jwt:Audience"),
                claims,
                expires: expirationTime,
                signingCredentials: credentials);

            string data = new JwtSecurityTokenHandler().WriteToken(token);

            return data;
        }
    }
}
