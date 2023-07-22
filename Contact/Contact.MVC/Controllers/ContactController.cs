using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Application.CQRS.Core;
using Contact.Application.Models.Request;
using Contact.Application.Models.Response;
using Contact.MVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contact.MVC.Controllers
{
    [Auth]
    public class ContactController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> List(GetUserContactRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5233/api/");
                Request.Cookies.TryGetValue("Token", out string? token);

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var response = await client.PostAsync("users/contacts", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

                string apiResponse = await response.Content.ReadAsStringAsync();

                var contactResponse = JsonConvert.DeserializeObject<ApiResult<GetUserContactResponse>>(apiResponse);

                return View();
            }
        }
    }
}

