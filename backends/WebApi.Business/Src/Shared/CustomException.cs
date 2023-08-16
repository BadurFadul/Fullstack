using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.Src.Shared
{
    public class CustomException:Exception
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public CustomException(int statusCode = 500, string errorMessage = "Internal server error")
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
        public static CustomException NotFoundException(string message ="Item cannot be found")
        {
            return new CustomException(404, message);
        }
         public static CustomException ForbiddenException(string message = "You do not have permission to perform this action")
        {
            return new CustomException(403, message);
        }

        public static CustomException BadRequestException(string message = "Bad request")
        {
            return new CustomException(400, message);
        }

        public static CustomException ConflictException(string message = "Resource conflict occurred")
        {
            return new CustomException(409, message);
        }

        public static CustomException UnauthorizedException(string message = "Unauthorized")
        {
            return new CustomException(401, message);
        }

        public static CustomException MethodNotAllowedException(string message = "Method not allowed")
        {
            return new CustomException(405, message);
        }
    }

}