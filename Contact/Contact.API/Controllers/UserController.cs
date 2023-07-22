using Contact.Application.CQRS.Core;
using Contact.Application.Interfaces;
using Contact.Application.Models.Request;
using Contact.Application.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
           => _userService = userService;

        #region GET Requests
        [HttpGet("contacts")]
        public async Task<ActionResult<ApiResult<GetUserContactResponse>>> GetUserContacts(GetUserContactRequest request)
        {
            return null;
        }


        [HttpGet("contacts/{contactId}")]
        public async Task<ActionResult<ApiResult<GetUserContactDetailByIdResponse>>>
            GetUserContactDetailById(GetUserContactDetailByIdRequest request)
        {
            return null;
        }

        #endregion

        #region POST Requests
        [HttpPost("contacts")]
        public async Task<ActionResult<ApiResult<CreateUserContactResponse>>> CreateUserContact(CreateUserContactRequest request)
        {
            return null;
        }
        #endregion

        #region PUT Requests
        [HttpPut("contacts/{contactId}")]
        public async Task<ActionResult<ApiResult<UpdateUserContactResponse>>> UpdateUserContact(UpdateUserContactRequest request)
        {
            return null;

        }
        #endregion

        #region DELETE Request
        [HttpDelete("contacts")]
        public async Task<ActionResult<ApiResult<DeleteUserContactResponse>>>
            DeleteUserContact(DeleteUserContactRequest request)

        {
            return null;
        }
        #endregion
    }
}