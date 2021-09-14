using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using MessageRouter.Application.Models;
using MessageRouter.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MessageRouter.Common;
using MessageRouter.Application.Models.EmailResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageRouter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;

        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }


        // POST api/<EmailController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult Post([FromBody] EmailModel emailInputModel)
        {
            _logger.LogInformation("EmailController.Post() called");

            var serverToken = GetHeader(Constants.HttpHeaders.PostmarkServerToken);
            var emailModels = new List<EmailModel> {emailInputModel};
            var emailResults = _emailService.SendEmails(emailModels, serverToken);

            var actionResult = DetermineHttpStatus(emailResults[0]);
            
            return actionResult;
        }

        // POST api/<EmailController>/batch
        ///
        [HttpPost("batch")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult PostBatch([FromBody] IEnumerable<EmailModel> emailModels)
        {
            _logger.LogInformation("EmailController.PostBatch() called");

            var serverToken = GetHeader(Constants.HttpHeaders.PostmarkServerToken);
            var emailResults = _emailService.SendEmails(emailModels.ToList(), serverToken);
            
            //Batch API appears to always return 200 with inidividual messages having differing codes
            return  Ok(emailResults);
        }
        private ActionResult DetermineHttpStatus(EmailResult emailResult)
        {
            return emailResult.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(),
                StatusCodes.Status401Unauthorized => Unauthorized(),
                StatusCodes.Status404NotFound => NotFound(),
                StatusCodes.Status422UnprocessableEntity => UnprocessableEntity(emailResult.ErrorDetail),
                //There is not built in ActionResults for these less common codes so just create it manually instead
                StatusCodes.Status429TooManyRequests => StatusCode(StatusCodes.Status429TooManyRequests),
                StatusCodes.Status503ServiceUnavailable => StatusCode(StatusCodes.Status503ServiceUnavailable),
                //StatusCode == 500 or something else unexpected happened
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };

        }

        private string GetHeader(string key)
        {
            if (Request.Headers.TryGetValue(key, out var value))
                return value.First();
            return null;
        }
    }
}
