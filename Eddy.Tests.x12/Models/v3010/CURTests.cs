using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*Oh*xIP*3653*9k*RAV*4IT*3lU*PIv1Kh*1OdZ*VJO*H9dVgj*9lEM*bTa*iXIuC6*uaMM*g3t*gJSHBr*G6Sk*lgw*zza5T3*FTza";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "Oh",
			CurrencyCode = "xIP",
			ExchangeRate = 3653,
			EntityIdentifierCode2 = "9k",
			CurrencyCode2 = "RAV",
			CurrencyMarketExchangeCode = "4IT",
			DateTimeQualifier = "3lU",
			Date = "PIv1Kh",
			Time = "1OdZ",
			DateTimeQualifier2 = "VJO",
			Date2 = "H9dVgj",
			Time2 = "9lEM",
			DateTimeQualifier3 = "bTa",
			Date3 = "iXIuC6",
			Time3 = "uaMM",
			DateTimeQualifier4 = "g3t",
			Date4 = "gJSHBr",
			Time4 = "G6Sk",
			DateTimeQualifier5 = "lgw",
			Date5 = "zza5T3",
			Time5 = "FTza",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Oh", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		subject.CurrencyCode = "xIP";
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xIP", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		subject.EntityIdentifierCode = "Oh";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
