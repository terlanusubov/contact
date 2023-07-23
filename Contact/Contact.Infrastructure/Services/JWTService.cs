using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Contact.Application.Interfaces;
using Contact.Domain.Entities;
using Contact.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Contact.Infrastructure.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public JWTService(IConfiguration configuration) => _configuration = configuration;

        public string GenerateJwtToken(User user)
        {
            var issuer = _configuration["JWTSettings:Issuer"];
            var audience = _configuration["JWTSettings:Audience"];
            var key = Encoding.ASCII.GetBytes
            (_configuration["JWTSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name),
                    new Claim("username", user.Username),
                new Claim("jti",  Guid.NewGuid().ToString().Replace("-","")),
             }),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JWTSettings:Expiration"])),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials

                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }

        public string ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWTSettings:Key"]);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
            var jti = jwtToken.Claims.First(x => x.Type == "jti").Value;

            return token;
        }
    }
}

