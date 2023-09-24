using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*CS*S75*2331*8v*OAc*Inx*o6V*7N4W4N*U40H*RcW*QZPN7E*Ly1J*lnr*y571ZS*kDT8*JeQ*IyHOZH*Z2ar*U35*QQ4eCp*yPWT";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "CS",
			CurrencyCode = "S75",
			ExchangeRate = 2331,
			EntityIdentifierCode2 = "8v",
			CurrencyCode2 = "OAc",
			CurrencyMarketExchangeCode = "Inx",
			DateTimeQualifier = "o6V",
			Date = "7N4W4N",
			Time = "U40H",
			DateTimeQualifier2 = "RcW",
			Date2 = "QZPN7E",
			Time2 = "Ly1J",
			DateTimeQualifier3 = "lnr",
			Date3 = "y571ZS",
			Time3 = "kDT8",
			DateTimeQualifier4 = "JeQ",
			Date4 = "IyHOZH",
			Time4 = "Z2ar",
			DateTimeQualifier5 = "U35",
			Date5 = "QQ4eCp",
			Time5 = "yPWT",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CS", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.CurrencyCode = "S75";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S75", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "CS";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
