using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Contact.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Contact.MVC.Filters;
using Contact.Application.CQRS.Core;
using Contact.Application.Models.Response;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Contact.MVC.Controllers;

[Auth]
public class HomeController : Controller
{
    public HomeController()
    {

    }

    public async Task<IActionResult> Index()
    {
        //using (HttpClient client = new HttpClient())
        //{
        //    client.BaseAddress = new Uri("http://localhost:5233/api/");

        //    foreach (var cookie in Request.Cookies)
        //    {
        //        client.DefaultRequestHeaders.Add("Cookie", $"{cookie.Key}={cookie.Value}");
        //    }

        //    var response = await client.GetAsync("account/check-token");

        //    string apiResponse = await response.Content.ReadAsStringAsync();

        //    var checkTokenResponse = JsonConvert.DeserializeObject<ApiResult<CheckTokenResponse>>(apiResponse);

        //    if (checkTokenResponse.StatusCode != (int)HttpStatusCode.OK)
        //        return View();

        //}

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

