namespace HippoValidator.W3CCSSValidationClient
{
    public class ValidationIssue
    {
        public Severity Severity { get; set; }

        public int? Row { get; set; }

        public int? Column { get; set; }

        public string Title { get; set; }

        public string MessageId { get; set; }
    }
}