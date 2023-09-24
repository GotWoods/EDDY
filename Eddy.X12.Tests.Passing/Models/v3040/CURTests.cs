using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*Rq*wyj*6829*VQ*ARI*6q3*z7j*XcO7os*IZbw*csx*glDvlp*5uIj*M1D*Jb8gyU*d7Yb*Asu*JdlBLc*E3ce*tJs*WbgE8V*0vBh";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "Rq",
			CurrencyCode = "wyj",
			ExchangeRate = 6829,
			EntityIdentifierCode2 = "VQ",
			CurrencyCode2 = "ARI",
			CurrencyMarketExchangeCode = "6q3",
			DateTimeQualifier = "z7j",
			Date = "XcO7os",
			Time = "IZbw",
			DateTimeQualifier2 = "csx",
			Date2 = "glDvlp",
			Time2 = "5uIj",
			DateTimeQualifier3 = "M1D",
			Date3 = "Jb8gyU",
			Time3 = "d7Yb",
			DateTimeQualifier4 = "Asu",
			Date4 = "JdlBLc",
			Time4 = "E3ce",
			DateTimeQualifier5 = "tJs",
			Date5 = "WbgE8V",
			Time5 = "0vBh",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rq", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wyj", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XcO7os", "z7j", true)]
	[InlineData("XcO7os", "", false)]
	[InlineData("", "z7j", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IZbw", "z7j", true)]
	[InlineData("IZbw", "", false)]
	[InlineData("", "z7j", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("glDvlp", "csx", true)]
	[InlineData("glDvlp", "", false)]
	[InlineData("", "csx", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5uIj", "csx", true)]
	[InlineData("5uIj", "", false)]
	[InlineData("", "csx", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jb8gyU", "M1D", true)]
	[InlineData("Jb8gyU", "", false)]
	[InlineData("", "M1D", true)]
	public void Validation_ARequiresBDate3(string date3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Date3 = date3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d7Yb", "M1D", true)]
	[InlineData("d7Yb", "", false)]
	[InlineData("", "M1D", true)]
	public void Validation_ARequiresBTime3(string time3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Time3 = time3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JdlBLc", "Asu", true)]
	[InlineData("JdlBLc", "", false)]
	[InlineData("", "Asu", true)]
	public void Validation_ARequiresBDate4(string date4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Date4 = date4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E3ce", "Asu", true)]
	[InlineData("E3ce", "", false)]
	[InlineData("", "Asu", true)]
	public void Validation_ARequiresBTime4(string time4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Time4 = time4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WbgE8V", "tJs", true)]
	[InlineData("WbgE8V", "", false)]
	[InlineData("", "tJs", true)]
	public void Validation_ARequiresBDate5(string date5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Date5 = date5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0vBh", "tJs", true)]
	[InlineData("0vBh", "", false)]
	[InlineData("", "tJs", true)]
	public void Validation_ARequiresBTime5(string time5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Rq";
		subject.CurrencyCode = "wyj";
		//Test Parameters
		subject.Time5 = time5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
