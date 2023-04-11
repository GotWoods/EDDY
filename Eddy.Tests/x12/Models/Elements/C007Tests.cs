using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C007Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "b*d*D*lP*rx*z*wu*X";

        var expected = new C007_AmountQualifyingDescription()
        {
            AmountQualifierCode = "b",
            AmountQualifierCode2 = "d",
            ValueDetailCode = "D",
            MeasurementSignificanceCode = "lP",
            UnitOfTimePeriodOrInterval = "rx",
            NetGrossCode = "z",
            MeasurementSignificanceCode2 = "wu",
            Description = "X",
        };

        var actual = Map.MapObject<C007_AmountQualifyingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("b", true)]
    public void Validatation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
    {
        var subject = new C007_AmountQualifyingDescription();
        subject.AmountQualifierCode = amountQualifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}