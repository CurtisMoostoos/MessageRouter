namespace MessageRouter.Domain.Models
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public string MessageStream { get; set; }
        public string Tag { get; set; }

        public bool IsValid => Validate();

        public string ValidationError { get; set; }

        private bool Validate()
        {
            //The validation of this object is likely too complex and would be a good candidate for the specification pattern
            //However for the purposes of this sample project this is easy to follow
            
            if (!IsWellFormattedEmail(To))
                return false;
            if (!IsWellFormattedEmail(From))
                return false;
            if (!IsTextOrHtml())
                return false;
            
            
            //Continue with other validations such as:
            // - Contains subject line
            // - Html properly formatted

            //If all passes
            return true;
        }

        /// <summary>
        /// Check email address is formatted correctly.
        /// Refer to https://en.wikipedia.org/wiki/Email_address#Syntax and corresponding RFCs
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsWellFormattedEmail(string email)
        {
            //Need to put in proper validation
            if (email.Contains('@'))
                return true;

            ValidationError = $"The email address \"{email}\" is invalid";
            return false;
        }

        private bool IsTextOrHtml()
        {
            //Check if 1 of TextBody or HtmlBody is set, but not both
            return true;
        }
        
    }
}
