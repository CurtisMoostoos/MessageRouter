using MessageRouter.Domain.Models;
using MessageRouter.Domain.Repositories;
using System;


namespace MessageRouter.Domain.Repositories
{
    public interface IEmailRepository
    {
        Guid AddEmailToOutGoingMessageQueue(Email emai);
        string GetStatusOfEmail(Guid emailId);
    }
}
