
using MessageRouter.Domain.Models;
using MessageRouter.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace MessageRouter.Infrastructure.TypeMappings
{
    public static class EmailToEmailModel
    {
        public static EmailModel Map(Email email)
        {
            return new EmailModel
            {
                From = email.From,
                To = email.To,
                Subject = email.Subject,
                Body = email.HtmlBody ?? email.TextBody,
                MessageStream = email.MessageStream,
                Tag = email.Tag
            };
        }

        public static List<EmailModel> Map(IEnumerable<Email> emails)
        {
            var emailModels = emails.Select(Map).ToList();
            return emailModels;
        }
    }
}
