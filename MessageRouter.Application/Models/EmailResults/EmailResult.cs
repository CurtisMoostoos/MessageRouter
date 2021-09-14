namespace MessageRouter.Application.Models.EmailResults
{
    public abstract class EmailResult
    {
        public int StatusCode { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

    }
}
