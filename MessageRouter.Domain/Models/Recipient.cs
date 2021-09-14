using System.Collections.Generic;

namespace MessageRouter.Domain.Models
{
    public class Recipient
    {
        public string EmailAddress { get; set; }

        public bool HasOptedOutOfAllEmail { get; set; }
        public List<string> TypesOfEmailNotInterestedIn { get; set; } 
    }
}
