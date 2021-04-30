using MavelArtist.Errors;
using MavelArtist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MavelArtist.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public MyErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var exception = context.Error;

            int code = 500;

            if(exception is MyNotFoundException)
            {
                code = 404;
            }
            else if (exception is MyBadRequestException ) {
                code = 400;
            }
            
            Response.StatusCode = code;

            return new MyErrorResponse(exception, code);
        }
    }
}
