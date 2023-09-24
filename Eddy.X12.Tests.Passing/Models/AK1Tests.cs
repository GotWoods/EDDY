using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AK1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AK1*sc*8*RjwURy44mLA8";

        var expected = new AK1_FunctionalGroupResponseHeader()
        {
            FunctionalIdentifierCode = "sc",
            GroupControlNumber = 8,
            VersionReleaseIndustryIdentifierCode = "RjwURy44mLA8",
        };

        var actual = Map.MapObject<AK1_FunctionalGroupResponseHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("sc", true)]
    public void Validation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
    {
        var subject = new AK1_FunctionalGroupResponseHeader();
        subject.GroupControlNumber = 1;
        subject.FunctionalIdentifierCode = functionalIdentifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
    {
        var subject = new AK1_FunctionalGroupResponseHeader();
        subject.FunctionalIdentifierCode = "sc";
        if (groupControlNumber > 0)
            subject.GroupControlNumber = groupControlNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}