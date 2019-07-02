using System;
using JWT.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        [NonAction]
        protected new OkObjectResult Ok(object value)
        {
            var newObject = GenerateResponse(value);

            return new OkObjectResult(newObject);
        }

        [NonAction]
        protected new OkObjectResult Ok()
        {
            var newObject = GenerateResponse(typeof(Nullable));

            return new OkObjectResult(newObject);
        }

        private static Response<TResponse> GenerateResponse<TResponse>(TResponse response)
        {
            return new Response<TResponse>
            {
                Errors = null,
                Success = true,
                Value = response
            };
        }
    }
}
