using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using School.Shared.AuthHelper;
using SchoolProject.Infrastructure.Identity;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementaion
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _settings;


        public JwtTokenService(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }
        public string GenerateToken(User user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
        {
            // Standard JWT claims
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),

            // Microsoft Identity claims
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName ?? ""),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim(ClaimTypes.StreetAddress,user.Address??"")
        };

            // Add roles
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);

            var token = new JwtSecurityToken
                (
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires:expires ,
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public DateTime GetExpiryUtc() => DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);
    }
}
