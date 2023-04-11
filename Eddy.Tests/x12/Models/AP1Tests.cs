using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AP1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AP1*mI*ZV*gjQ*2*8*yDT*jBw*A1*5*4*O*d*x";

        var expected = new AP1_AlternateParts
        {
            ConditionIndicatorCode = "mI",
            StateOrProvinceCode = "ZV",
            PriceIdentifierCode = "gjQ",
            PercentageAsDecimal = 2,
            MonetaryAmount = 8,
            PostalCode = "yDT",
            PostalCode2 = "jBw",
            PrintOptionCode = "A1",
            Number = 5,
            Quantity = 4,
            FreeFormInformation = "O",
            ProductServiceID = "d",
            Description = "x"
        };

        var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("mI", true)]
    public void Validatation_RequiredConditionIndicatorCode(string conditionIndicatorCode, bool isValidExpected)
    {
        var subject = new AP1_AlternateParts();
        subject.ConditionIndicatorCode = conditionIndicatorCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "yDT", true)]
    [InlineData("jBw", "", false)]
    public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
    {
        var subject = new AP1_AlternateParts();
        subject.ConditionIndicatorCode = "mI";
        subject.PostalCode2 = postalCode2;
        subject.PostalCode = postalCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}