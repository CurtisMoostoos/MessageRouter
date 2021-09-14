using MessageRouter.Domain.Models;

namespace MessageRouter.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string serverToken);
    }
}
