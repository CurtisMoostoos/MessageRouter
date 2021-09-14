using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static MessageRouter.Common.Constants;

namespace MessageRouter.Api.Authentication
{
    public class ServerTokenValidator
    {
        private readonly RequestDelegate _next;
        public ServerTokenValidator(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains(HttpHeaders.PostmarkServerToken))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized; //Bad Request                
                await context.Response.WriteAsync("Missing or incorrect API token in header");
                return;
            }

            //This would also be a good place to enforce Rate Limit Exceeded

            await _next.Invoke(context);
        }
    }
}
