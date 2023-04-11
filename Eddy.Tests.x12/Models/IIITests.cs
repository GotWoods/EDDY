using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IIITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "III*s*n*1b*e*2**vY*TI*6I";

        var expected = new III_Information
        {
            CodeListQualifierCode = "s",
            IndustryCode = "n",
            CodeCategory = "1b",
            FreeFormMessageText = "e",
            Quantity = 2,
            CompositeUnitOfMeasure = null,
            SurfaceLayerPositionCode = "vY",
            SurfaceLayerPositionCode2 = "TI",
            SurfaceLayerPositionCode3 = "6I"
        };

        var actual = Map.MapObject<III_Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("s", "n", true)]
    [InlineData("", "n", false)]
    [InlineData("s", "", false)]
    public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
    {
        var subject = new III_Information();
        subject.CodeListQualifierCode = codeListQualifierCode;
        subject.IndustryCode = industryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", 0, true)]
    [InlineData("1b", "", 0, false)]
    [InlineData("", "e", 0, true)]
    [InlineData("1b", "", 1, true)]
    public void Validation_IfOneSpecifiedThenOneMoreRequired_CodeCategory(string codeCategory, string freeFormMessageText, decimal quantity, bool isValidExpected)
    {
        var subject = new III_Information();
        subject.CodeCategory = codeCategory;
        subject.FreeFormMessageText = freeFormMessageText;
        if (quantity > 0)
            subject.Quantity = quantity;
        //
        // if (codeCategory != "")
        //     subject.FreeFormMessageText = "AAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }
}