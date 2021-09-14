using MessageRouter.Common;

namespace MessageRouter.Application.Models.EmailResults
{
    public class InvalidToken : EmailResult
    {
        public InvalidToken()
        {
            StatusCode = (int)Enumerations.HttpStatusCodes.Unauthorized;
            ErrorDetail = new ErrorDetail
            {
                ErrorCode = (int)Enumerations.ApiErrorCodes.BadOrMissingApiToken,
                Message = "Bad Or Missing Api Token."
            };
        }
    }
}
