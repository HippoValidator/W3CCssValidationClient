using System.Collections.Generic;

namespace HippoValidator.W3CCSSValidationClient
{
    public class ValidationResult
    {
        public List<ValidationIssue> Errors { get; set; }

        public List<ValidationIssue> Warnings { get; set; }
    }
}