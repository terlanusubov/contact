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
        [HttpGet]
        public async Task<ActionResult<string>> GetUsers(GetUserRequest request)
        {
            return null;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ApiResult<GetUserByIdResponse>>> GetUserById(string userId)
        {
            return null;
        }

        [HttpGet("{userId}/contacts")]
        public async Task<ActionResult<ApiResult<GetUserContactResponse>>> GetUserContacts(GetUserContactRequest request)
        {
            return null;
        }


        [HttpGet("{userId}/contacts/{contactId}")]
        public async Task<ActionResult<ApiResult<GetUserContactDetailByIdResponse>>>
            GetUserContactDetailById(GetUserContactDetailByIdRequest request)
        {
            return null;
        }

        #endregion

        #region POST Requests
        [HttpPost("{userId}/contacts")]
        public async Task<ActionResult<ApiResult<CreateUserContactResponse>>> CreateUserContact(CreateUserContactRequest request)
        {
            return null;
        }
        #endregion

        #region PUT Requests
        [HttpPut("{userId}/contacts/{contactId}")]
        public async Task<ActionResult<ApiResult<UpdateUserContactResponse>>> UpdateUserContact(UpdateUserContactRequest request)
        {
            return null;

        }
        #endregion

        #region DELETE Request
        public async Task<ActionResult<ApiResult<DeleteUserContactResponse>>>
            DeleteUserContact(DeleteUserContactRequest request)

        {
            return null;
        }
        #endregion
    }
}