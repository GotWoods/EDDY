using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N9Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N9*cl*w*Z*IRGixeTT*OdTn*xF*";

        var expected = new N9_ExtendedReferenceInformation()
        {
            ReferenceIdentificationQualifier = "cl",
            ReferenceIdentification = "w",
            FreeFormDescription = "Z",
            Date = "IRGixeTT",
            Time = "OdTn",
            TimeCode = "xF",
            //   ReferenceIdentifier = "",
        };

        var actual = Map.MapObject<N9_ExtendedReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
    {
        var subject = new N9_ExtendedReferenceInformation();
        subject.ReferenceIdentification = "1";
        subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", false)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string freeFormDescription, bool isValidExpected)
    {
        var subject = new N9_ExtendedReferenceInformation();
        subject.ReferenceIdentificationQualifier = "AB";
        subject.ReferenceIdentification = referenceIdentification;
        subject.FreeFormDescription = freeFormDescription;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "1234", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
    {
        var subject = new N9_ExtendedReferenceInformation();
        subject.ReferenceIdentification = "1";
        subject.ReferenceIdentificationQualifier = "AB";

        subject.TimeCode = timeCode;
        subject.Time = time;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}