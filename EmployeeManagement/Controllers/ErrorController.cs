using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, we didn't find the page you requested";
                    logger.LogWarning($"404 error accured. path = {statusCodeResult.OriginalPath} and " +
                        $"query string = {statusCodeResult.OriginalQueryString}");
                    break;

            }
            return View("NotFound");
        }

        [Route("/Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError("the path {0} threw an exception {1}", exceptionDetails.Path, 
                exceptionDetails.Error);

            return View("Error");
        }
    }
}