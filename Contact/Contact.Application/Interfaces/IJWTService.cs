using System;
using Contact.Domain.Entities;

namespace Contact.Application.Interfaces
{
    public interface IJWTService
    {
        public string GenerateJwtToken(User user);
        public string ValidateJwtToken(string token);
    }
}

