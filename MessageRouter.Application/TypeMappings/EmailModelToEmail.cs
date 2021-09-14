using System.Collections.Generic;
using System.Linq;
using MessageRouter.Application.Models;
using MessageRouter.Domain.Models;

namespace MessageRouter.Application.TypeMappings
{
    public static class EmailModelToEmail
    {
        /*
         * Typically I would use something like AutoMapper for anything with any more complexity than this
         */
        public static Email Map(EmailModel emailModel)
        {
            return new Email
            {
                From = emailModel.From,
                To = emailModel.To,
                Subject = emailModel.Subject,
                HtmlBody = emailModel.HtmlBody,
                TextBody = emailModel.TextBody,
                MessageStream = emailModel.MessageStream,
                Tag = emailModel.Tag
            };
        }

        public static List<Email> Map(IEnumerable<EmailModel> emailModels)
        {
            var emails = emailModels.Select(Map).ToList();
            return emails;
        }
    }
}
