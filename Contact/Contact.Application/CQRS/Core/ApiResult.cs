using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Contact.Domain.Enums;
using Contact.Domain.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contact.Application.CQRS.Core
{
    public class ApiResult<TOutput>
    {
        public TOutput Response { get; set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Description { get; set; }


        public static ApiResult<TOutput> OK(TOutput response)
        {
            return new ApiResult<TOutput>()
            {
                Response = response,
                StatusCode = (int)HttpStatusCode.OK,
                Description = "The operation has finished successfully.",
            };
        }


        public static ApiResult<TOutput> Error(ErrorCodes errorCode, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ApiResult<TOutput>()
            {
                Response = default,
                StatusCode = statusCode,
                ErrorCode = (int)errorCode,
                Description = errorCode.GetEnumDescription()
            };
        }
    }
}
