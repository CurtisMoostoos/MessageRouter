using static MessageRouter.Common.Enumerations;

namespace MessageRouter.Application.Models.EmailResults
{
    public class ViolatesTermsOfService : EmailResult
    {
        public ViolatesTermsOfService()
        {
            StatusCode = (int)HttpStatusCodes.UnProcessableEntity;
            ErrorDetail = new ErrorDetail
            {
                ErrorCode = (int)ApiErrorCodes.ViolatesTermsOfService,
                Message = "Message body violates terms of service."
            };        
        }
    }
}
