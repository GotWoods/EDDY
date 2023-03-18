using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models
{
    public class L11Tests
    {
        [Fact]
        public void Parse_ShouldReturnCorrectObject()
        {
            string x12Line = "L11*N*KJ*d*1gZJnsqY*v";

            var expected = new L11_BusinessInstructionsAndReferenceNumber()
            {
                ReferenceIdentification = "N",
                ReferenceIdentificationQualifier = "KJ",
                Description = "d",
                Date = "1gZJnsqY",
                YesNoConditionOrResponseCode = "v",
            };

            var actual = Map.MapObject<L11_BusinessInstructionsAndReferenceNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
            Assert.Equivalent(expected, actual);
        }

        [Theory]
        [InlineData("", "", true)]
        [InlineData("v1", "v2", true)]
        [InlineData("", "v2", false)]
        [InlineData("v1", "", false)]
        public void Validatation_RequiredReferenceIdentification(string referenceIdentification, string referenceIdentificationQualifier, bool isValidExpected)
        {
            var subject = new L11_BusinessInstructionsAndReferenceNumber();
            subject.Description = "description";
            subject.ReferenceIdentification = referenceIdentification;
            subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
            TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
        }

        [Theory]
        [InlineData("", "", false)]
        [InlineData("v1", "v2", true)]
        [InlineData("", "v2", true)]
        [InlineData("v1", "", true)]
        public void Validatation_ReferenceIdentificationOrDescriptionRequired(string referenceIdentification, string description, bool isValidExpected)
        {
            var subject = new L11_BusinessInstructionsAndReferenceNumber();
            subject.ReferenceIdentification = referenceIdentification;
            if (referenceIdentification != "")
                subject.ReferenceIdentificationQualifier = "R1"; //this is required if a reference id is set
            subject.Description = description;
            TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
        }
    }
}
