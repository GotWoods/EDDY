using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C999Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "q*z";

        var expected = new C999_ReferenceInSegment()
        {
            DataElementReferenceCode = "q",
            DataElementReferenceCode2 = "z",
        };

        var actual = Map.MapObject<C999_ReferenceInSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("q", true)]
    public void Validatation_RequiredDataElementReferenceCode(string dataElementReferenceCode, bool isValidExpected)
    {
        var subject = new C999_ReferenceInSegment();
        subject.DataElementReferenceCode = dataElementReferenceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}