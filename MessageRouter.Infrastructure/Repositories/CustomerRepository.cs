using MessageRouter.Domain.Models;
using MessageRouter.Domain.Repositories;
using System.Collections.Generic;

namespace MessageRouter.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(string serverToken)
        {
            //This class likely would query an relational database.
            //Caching may be advantageous if customers are often making multiple calls to the  single email API,
            //rather than the batch API

            return new Customer
            {
                ServerToken = serverToken,
                IsAccountActive = true,
                ValidSenders = new List<string>
                {
                    "sender@domain.com",
                    "administrator@domain.com"
                }
            };
        }
    }
}
