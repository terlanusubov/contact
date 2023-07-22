using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contact.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int GetUser()
        {
            string userIdValue = HttpContext.User.Claims.Where(c => c.Type == "id").Select(c => c.Value).FirstOrDefault();

            return userIdValue == null ? 0 : Convert.ToInt32(userIdValue);
        }
    }
}

