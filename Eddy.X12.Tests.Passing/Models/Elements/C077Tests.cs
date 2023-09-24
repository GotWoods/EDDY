using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C077Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "7*C0v*5*pjH*2*wv6";

        var expected = new C077_CompositeCurrency()
        {
            UnitPrice = 7,
            CurrencyCode = "C0v",
            UnitPrice2 = 5,
            CurrencyCode2 = "pjH",
            UnitPrice3 = 2,
            CurrencyCode3 = "wv6",
        };

        var actual = Map.MapObject<C077_CompositeCurrency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(7, true)]
    public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
    {
        var subject = new C077_CompositeCurrency();
        subject.CurrencyCode = "C0v";
        if (unitPrice > 0)
            subject.UnitPrice = unitPrice;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("C0v", true)]
    public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
    {
        var subject = new C077_CompositeCurrency();
        subject.UnitPrice = 7;
        subject.CurrencyCode = currencyCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}