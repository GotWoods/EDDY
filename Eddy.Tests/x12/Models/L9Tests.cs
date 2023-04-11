using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L9Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "L9*B99*5";

        var expected = new L9_ChargeDetail()
        {
            SpecialChargeOrAllowanceCode = "B99",
            MonetaryAmount = 5,
        };

        var actual = Map.MapObject<L9_ChargeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("123", true)]
    public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
    {
        var subject = new L9_ChargeDetail();
        subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
        subject.MonetaryAmount = 1;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
    {
        var subject = new L9_ChargeDetail();
        subject.SpecialChargeOrAllowanceCode = "123";

        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}