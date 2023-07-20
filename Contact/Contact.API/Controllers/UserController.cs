using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return "test";
        }
    }
}