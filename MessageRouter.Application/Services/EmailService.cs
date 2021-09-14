using System.Collections.Generic;
using MessageRouter.Application.Models;
using MessageRouter.Application.Models.EmailResults;
using MessageRouter.Domain.Repositories;

namespace MessageRouter.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly INaturalLanguageRepository _naturalLanguageRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRecipientRepository _recipientRepository;
        private readonly IEmailRepository _emailRepository;
        public EmailService(INaturalLanguageRepository naturalLanguageRepository, 
                            ICustomerRepository customerRepository,
                            IRecipientRepository recipientRepository,
                            IEmailRepository emailRepository)
        {
            _naturalLanguageRepository = naturalLanguageRepository;
            _customerRepository = customerRepository;
            _recipientRepository = recipientRepository;
            _emailRepository = emailRepository;
        }
        
        
        public List<EmailResult> SendEmails(List<EmailModel> emailModels, string serverToken)
        {            
            var emailResults = new List<EmailResult>();
            var customer = _customerRepository.GetCustomer(serverToken);
            
            //Run checks that pertain to the entire batch
            if (!IsBatchSendable(customer, emailResults))
            {
                return emailResults;
            }

            var emails = TypeMappings.EmailModelToEmail.Map(emailModels);

            foreach (var email in emails)
            {
                if (IsEmailSendable(email, customer, emailResults))
                {
                    var emailId = _emailRepository.AddEmailToOutGoingMessageQueue(email);

                    //The implementation of this method should be include retry logic.
                    //We have introduced a race between this and the item waiting to be processed in the queue
                    var sentEmailStatus = _emailRepository.GetStatusOfEmail(emailId);
                    var sentEmailResult = DetermineEmailResultFromStatus(sentEmailStatus);
                    emailResults.Add(sentEmailResult);
                }          
            }
            return emailResults;
        }

        private EmailResult DetermineEmailResultFromStatus(string sentEmailStatus)
        {
            //For now just assume they are all successful. We would in fact be looking for things like if a bounce back occurred
            return new Success();
        }

        private bool IsEmailSendable(Domain.Models.Email email, Domain.Models.Customer customer, List<EmailResult> emailResults)
        {
            var recipient = _recipientRepository.GetRecipient(email.To);

            if (!email.IsValid)
            {
                emailResults.Add(new InvalidEmail(email.ValidationError));
                return false;
            }
            else if (!customer.ValidSenders.Contains(email.From))
            {
                emailResults.Add(new InvalidSender());
                return false;
            }

            else if (recipient.HasOptedOutOfAllEmail || recipient.TypesOfEmailNotInterestedIn.Contains(email.Tag))
            {
                emailResults.Add(new OptedOut());
                return false;
            }

            //Sent out message body to the natural language processing service to see if this violates term of service
            else if (!_naturalLanguageRepository.GetMachineLearningClassificationOfContent(email.HtmlBody ?? email.TextBody))
            {
                emailResults.Add(new ViolatesTermsOfService());
                return false;
            }
            return true;
        }

        private bool IsBatchSendable(Domain.Models.Customer customer, List<EmailResult> emailResults)
        {
            var isBatchSendable = true;
            if (customer is null || !customer.IsAccountActive)
            {
                emailResults.Add(new InvalidToken());
                isBatchSendable = false;
            }

            return isBatchSendable;
        }
    }
}
