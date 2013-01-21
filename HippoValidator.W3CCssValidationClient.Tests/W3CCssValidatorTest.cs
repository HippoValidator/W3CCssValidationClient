using System;
using System.Linq;
using HippoValidator.W3CCSSValidationClient;
using NUnit.Framework;

namespace HippoValidator.W3CCssValidationClient.Tests
{
    public class W3CCssValidatorTest
    {
        [Test]
        public void CanCalidateWebsite()
        {
            // Arrange
            var validator = new W3CCssValidator();

            // Act
            var result = validator.Validate(new Uri("http://www.hippovalidator.com"));

            // Assert
            Assert.That(result.Errors.Any());
            Assert.That(result.Warnings.Any());
        }
    }
}
