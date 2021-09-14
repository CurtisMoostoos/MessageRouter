using static MessageRouter.Common.Enumerations;

namespace MessageRouter.Application.Models.EmailResults
{
    public class InvalidEmail : EmailResult
    {
        public InvalidEmail(string message)
        {
            StatusCode = (int)HttpStatusCodes.UnProcessableEntity;
            ErrorDetail = new ErrorDetail
            {
                ErrorCode = (int)ApiErrorCodes.InvalidEmailRequest,
                Message = message
            };
        }
    }
}
