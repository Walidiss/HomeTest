﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using GetDinners.Api.Common.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GetDinners.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        //protected IActionResult Problem(List<Error> errors)
        // {
        //     HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        //     var firstError = errors[0];
        //     var statusCode = firstError.Type switch
        //     {
        //         ErrorType.Conflict => StatusCodes.Status409Conflict,
        //         ErrorType.Validation => StatusCodes.Status400BadRequest,
        //         ErrorType.NotFound => StatusCodes.Status404NotFound,
        //         _ => StatusCodes.Status500InternalServerError
        //     };

        //     return Problem(statusCode: statusCode, title: firstError.Description);
        // }


        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError

            };
            return Problem(statusCode: statusCode, title: error.Description);

        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionnary = new ModelStateDictionary();
            foreach(var error in errors)
            {
                modelStateDictionnary.AddModelError(
                    error.Code,
                    error.Description
                    );
            }
            return ValidationProblem(modelStateDictionnary);
        }
    }
}
