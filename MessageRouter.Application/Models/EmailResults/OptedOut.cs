using MessageRouter.Common;

namespace MessageRouter.Application.Models.EmailResults
{
    public class OptedOut : EmailResult
    {
        public OptedOut()
        {
            //Should an opted out be considered a success, or should some other result be returned?
            StatusCode = (int)Enumerations.HttpStatusCodes.Success;
        }
    }
}
