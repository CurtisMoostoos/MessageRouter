using MessageRouter.Domain.Models;
using MessageRouter.Domain.Repositories;
using MessageRouter.Infrastructure.Models;
using System;

namespace MessageRouter.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public Guid AddEmailToOutGoingMessageQueue(Email email)
        {
            //I am envisioning that this will be posted to another rest API which will
            //be essentially a wrapper around message queue. and will handle incoming and outgoing
            //interaction with the message queue.

            //emails from the queue will be pushed to a seperate service which will handle the actual sending of the emails
            //When  sent, a record will be added to a database which will list what the status of that send attempt was.

            throw new NotImplementedException();
        }

        public string GetStatusOfEmail(Guid emailId)
        {
            //This method would need to handle the retry logic while waiting for the email to be sent
            throw new NotImplementedException();
        }
    }
}
