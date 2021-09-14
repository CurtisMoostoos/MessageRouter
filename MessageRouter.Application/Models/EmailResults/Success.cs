using MessageRouter.Common;

namespace MessageRouter.Application.Models.EmailResults
{
    public class Success : EmailResult
    {
        public Success()
        {
            StatusCode = (int)Enumerations.HttpStatusCodes.Success;
            ErrorDetail = new ErrorDetail
            {
                ErrorCode = (int)Enumerations.ApiErrorCodes.Ok,
                Message = "Ok."
            };
        }
    }
}
