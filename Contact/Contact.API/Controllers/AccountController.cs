using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Application.CQRS.Core;
using Contact.Application.Interfaces;
using Contact.Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) => _accountService = accountService;

        [HttpPost("login")]
        public async Task<ActionResult<ApiResult<LoginResponse>>> Login(LoginRequest request)
        => await _accountService.Login(request);

    }
}

