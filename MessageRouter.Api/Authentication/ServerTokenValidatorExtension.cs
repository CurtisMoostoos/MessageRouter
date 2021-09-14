using Microsoft.AspNetCore.Builder;

namespace MessageRouter.Api.Authentication
{
    public static class ServerTokenValidatorExtension
    {
        public static IApplicationBuilder UseServerTokenValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<ServerTokenValidator>();
            return app;
        }
    }
}
