using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class C3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "C3*kkD*fXKD*pCi*ZnG";

        var expected = new C3_CurrencyIdentifier()
        {
            CurrencyCode = "kkD",
            ExchangeRate = "fXKD",
            CurrencyCode2 = "pCi",
            CurrencyCode3 = "ZnG",
        };

        var actual = Map.MapObject<C3_CurrencyIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("123", true)]
    public void Validatation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
    {
        var subject = new C3_CurrencyIdentifier();
        subject.CurrencyCode = currencyCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}