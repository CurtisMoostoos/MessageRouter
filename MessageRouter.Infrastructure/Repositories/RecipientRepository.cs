using System.Collections.Generic;
using MessageRouter.Domain.Models;
using MessageRouter.Domain.Repositories;

namespace MessageRouter.Infrastructure.Repositories
{
    public class RecipientRepository : IRecipientRepository
    {
        public Recipient GetRecipient(string emailAddress)
        {
            //Rerieve from database
            return new Recipient
            {
                EmailAddress = "Recipient@domain.com",
                HasOptedOutOfAllEmail = false,
                TypesOfEmailNotInterestedIn = new List<string>
                {
                    "Marketing"
                }

            };
        }
    }
}
