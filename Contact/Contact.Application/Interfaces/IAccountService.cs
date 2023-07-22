using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Application.CQRS.Core;
using Contact.Application.Models.Request;
using Contact.Application.Models.Response;

namespace Contact.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResult<LoginResponse>> Login(LoginRequest request);
        Task<ApiResult<RegisterResponse>> Register(RegisterRequest request);
    }
}
