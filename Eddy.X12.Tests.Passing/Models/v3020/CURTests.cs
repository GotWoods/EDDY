using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*1G*rKK*2896*jU*Exi*56z*xYn*teKwc1*XW5H*17H*nGA3pe*iMA6*Tdv*nx9Y0y*v8NT*2Dc*9ZezhP*7grE*sXG*STQVPY*MbJg";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "1G",
			CurrencyCode = "rKK",
			ExchangeRate = 2896,
			EntityIdentifierCode2 = "jU",
			CurrencyCode2 = "Exi",
			CurrencyMarketExchangeCode = "56z",
			DateTimeQualifier = "xYn",
			Date = "teKwc1",
			Time = "XW5H",
			DateTimeQualifier2 = "17H",
			Date2 = "nGA3pe",
			Time2 = "iMA6",
			DateTimeQualifier3 = "Tdv",
			Date3 = "nx9Y0y",
			Time3 = "v8NT",
			DateTimeQualifier4 = "2Dc",
			Date4 = "9ZezhP",
			Time4 = "7grE",
			DateTimeQualifier5 = "sXG",
			Date5 = "STQVPY",
			Time5 = "MbJg",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1G", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rKK", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("teKwc1", "xYn", true)]
	[InlineData("teKwc1", "", false)]
	[InlineData("", "xYn", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XW5H", "xYn", true)]
	[InlineData("XW5H", "", false)]
	[InlineData("", "xYn", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nGA3pe", "17H", true)]
	[InlineData("nGA3pe", "", false)]
	[InlineData("", "17H", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iMA6", "17H", true)]
	[InlineData("iMA6", "", false)]
	[InlineData("", "17H", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nx9Y0y", "Tdv", true)]
	[InlineData("nx9Y0y", "", false)]
	[InlineData("", "Tdv", true)]
	public void Validation_ARequiresBDate3(string date3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Date3 = date3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v8NT", "Tdv", true)]
	[InlineData("v8NT", "", false)]
	[InlineData("", "Tdv", true)]
	public void Validation_ARequiresBTime3(string time3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Time3 = time3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9ZezhP", "2Dc", true)]
	[InlineData("9ZezhP", "", false)]
	[InlineData("", "2Dc", true)]
	public void Validation_ARequiresBDate4(string date4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Date4 = date4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7grE", "2Dc", true)]
	[InlineData("7grE", "", false)]
	[InlineData("", "2Dc", true)]
	public void Validation_ARequiresBTime4(string time4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Time4 = time4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("STQVPY", "sXG", true)]
	[InlineData("STQVPY", "", false)]
	[InlineData("", "sXG", true)]
	public void Validation_ARequiresBDate5(string date5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Date5 = date5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MbJg", "sXG", true)]
	[InlineData("MbJg", "", false)]
	[InlineData("", "sXG", true)]
	public void Validation_ARequiresBTime5(string time5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "1G";
		subject.CurrencyCode = "rKK";
		//Test Parameters
		subject.Time5 = time5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
