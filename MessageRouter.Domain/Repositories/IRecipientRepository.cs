using MessageRouter.Domain.Models;

namespace MessageRouter.Domain.Repositories
{
    public interface IRecipientRepository
    {
        Recipient GetRecipient(string emailAddress);
    }
}
