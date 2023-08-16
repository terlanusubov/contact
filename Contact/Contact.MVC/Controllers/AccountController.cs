using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contact.Application.CQRS.Core;
using Contact.Application.Models.Request;
using Contact.Application.Models.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contact.MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://contact-api.hra.az/api/");

                var response = await client.PostAsync("account/login", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

                string apiResponse = await response.Content.ReadAsStringAsync();

                var loginResponse = JsonConvert.DeserializeObject<ApiResult<LoginResponse>>(apiResponse);

                if (loginResponse.StatusCode != (int)HttpStatusCode.OK)
                    return View(request);

                Response.Cookies.Append("Token", loginResponse.Response.Token, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Domain = ".hra.az",
                    Expires = DateTime.UtcNow.AddHours(5),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None
                });

                var claims = new List<Claim>
                  {
                      new Claim("jwt_token",loginResponse.Response.Token ),
                  };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://contact-api.hra.az/api/");

                var response = await client.PostAsync("account/register", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

                string apiResponse = await response.Content.ReadAsStringAsync();

                var registerResponse = JsonConvert.DeserializeObject<ApiResult<LoginResponse>>(apiResponse);

                if (registerResponse?.StatusCode != (int)HttpStatusCode.OK)
                    return View(request);

                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("Token");
            return RedirectToAction("Index", "Home");
        }
    }
}

