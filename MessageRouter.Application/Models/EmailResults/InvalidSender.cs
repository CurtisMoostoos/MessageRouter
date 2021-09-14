using MessageRouter.Common;

namespace MessageRouter.Application.Models.EmailResults
{
    public class InvalidSender : EmailResult
    {
        public InvalidSender()
        {
            StatusCode = (int)Enumerations.HttpStatusCodes.Unauthorized;
            ErrorDetail = new ErrorDetail
            {
                ErrorCode = (int)Enumerations.ApiErrorCodes.SenderSignatureNotFound,
                Message = "From address is not a registered sender."
            };
        }
    }
}
