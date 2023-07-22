using Contact.Application.CQRS.Core;
using Contact.Application.Interfaces;
using Contact.Application.Models.Request;
using Contact.Application.Models.Response;
using Contact.Domain.Entities;
using Contact.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AccountService(ApplicationDbContext context,
                              IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ApiResult<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Username == request.Username);

            if (user == null)
            {
                return null;
            }


            var issuer = _configuration["JWTSettings:Issuer"];
            var audience = _configuration["JWTSettings:Audience"];
            var key = Encoding.ASCII.GetBytes
            (_configuration["JWTSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("id", Guid.NewGuid().ToString()),
                new Claim("name", user.Name),
                    new Claim("username", user.Username),
                new Claim("jti",  Guid.NewGuid().ToString().Replace("-","")),
                new Claim("audiences","")
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

            return null;

        }

        public Task<ApiResult<RegisterResponse>> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
