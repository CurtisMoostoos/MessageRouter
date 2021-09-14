using System.Collections.Generic;

namespace MessageRouter.Domain.Models
{
    public class Customer
    {
        public string ServerToken { get; set; }
        public bool IsAccountActive { get; set; }
        public List<string> ValidSenders { get; set; }
        public int ReputationScore { get; set; }

    }
}
