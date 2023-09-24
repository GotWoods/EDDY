using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class REFTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "REF*8o*H*n*";

        var expected = new REF_ReferenceInformation()
        {
            ReferenceIdentificationQualifier = "8o",
            ReferenceIdentification = "H",
            Description = "n",
            ReferenceIdentifier = null,
        };

        var actual = Map.MapObject<REF_ReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("8o", true)]
    public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
    {
        var subject = new REF_ReferenceInformation();
        subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", false)]
    [InlineData("H", "n", true)]
    [InlineData("", "n", true)]
    [InlineData("H", "", true)]
    public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
    {
        var subject = new REF_ReferenceInformation();
        subject.ReferenceIdentificationQualifier = "8o";
        subject.ReferenceIdentification = referenceIdentification;
        subject.Description = description;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

}