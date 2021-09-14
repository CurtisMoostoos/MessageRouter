namespace MessageRouter.Common
{
    public class Enumerations
    {
        public enum ApiErrorCodes
        {
            Ok = 0,
            BadOrMissingApiToken = 10,
            Maintenance = 100,
            InvalidEmailRequest = 300,
            SenderSignatureNotFound = 400,
            ViolatesTermsOfService = 999
        }

        public enum HttpStatusCodes
        {
            Success = 200,
            Unauthorized = 401,
            NotFound = 404,
            UnProcessableEntity = 422
        }
    }
}
