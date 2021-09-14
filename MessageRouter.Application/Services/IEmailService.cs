using System.Collections.Generic;
using MessageRouter.Application.Models;
using MessageRouter.Application.Models.EmailResults;

namespace MessageRouter.Application.Services
{
    public interface IEmailService
    {
        List<EmailResult> SendEmails(List<EmailModel> emailModels, string serverToken);
    }
}
