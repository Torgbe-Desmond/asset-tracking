using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Asset_Tracking.Infrastructure.Identity
{
    public class JwtService : IJwtService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiryMinutes;

        public JwtService(IConfiguration config)
        {
            var section = config.GetSection("jwtConfig");

            _secret = section["Key"]
                ?? throw new InvalidOperationException("JWT Key ('jwtConfig:Key') is not configured.");

            _issuer = section["Issuer"]
                ?? throw new InvalidOperationException("JWT Issuer ('jwtConfig:Issuer') is not configured.");

            _audience = section["Audience"]
                ?? throw new InvalidOperationException("JWT Audience ('jwtConfig:Audience') is not configured.");

            _expiryMinutes = int.TryParse(section["ExpiryMinutes"], out var exp) ? exp : 60;
        }

        public string GenerateToken(ApplicationUser user)
        {
            if (string.IsNullOrWhiteSpace(_secret) || _secret.Length < 32)
                throw new InvalidOperationException("JWT secret key must be at least 32 characters long.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}