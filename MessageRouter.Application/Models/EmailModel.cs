namespace MessageRouter.Application.Models
{
    public class EmailModel
    {
        /*
         * It is tempting to use the domain model across the entire solution and this class
         * Having separate "view models" (For lack of a better term) is usually worth the extra effort
         * Prevents over-posting vulnerabilities and keeps your domain clean if you APIs evolve over time
         */
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public string MessageStream { get; set; }
        public string Tag { get; set; }

    }
}
