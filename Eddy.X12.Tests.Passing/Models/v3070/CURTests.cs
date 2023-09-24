using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*Xc*841*5314*0D*Cfd*067*vFL*VYfwp0*pxum*BUO*eDabQ3*76Je*tQq*odI2d2*QN4h*bQB*uQxDad*mtSZ*DG4*pWKW5v*f30X";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "Xc",
			CurrencyCode = "841",
			ExchangeRate = 5314,
			EntityIdentifierCode2 = "0D",
			CurrencyCode2 = "Cfd",
			CurrencyMarketExchangeCode = "067",
			DateTimeQualifier = "vFL",
			Date = "VYfwp0",
			Time = "pxum",
			DateTimeQualifier2 = "BUO",
			Date2 = "eDabQ3",
			Time2 = "76Je",
			DateTimeQualifier3 = "tQq",
			Date3 = "odI2d2",
			Time3 = "QN4h",
			DateTimeQualifier4 = "bQB",
			Date4 = "uQxDad",
			Time4 = "mtSZ",
			DateTimeQualifier5 = "DG4",
			Date5 = "pWKW5v",
			Time5 = "f30X",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xc", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("841", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VYfwp0", "vFL", true)]
	[InlineData("VYfwp0", "", false)]
	[InlineData("", "vFL", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pxum", "vFL", true)]
	[InlineData("pxum", "", false)]
	[InlineData("", "vFL", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("BUO", "eDabQ3", "76Je", true)]
	[InlineData("BUO", "", "", false)]
	[InlineData("", "eDabQ3", "76Je", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "BUO";
		if (time2 != "")
			subject.DateTimeQualifier2 = "BUO";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eDabQ3", "BUO", true)]
	[InlineData("eDabQ3", "", false)]
	[InlineData("", "BUO", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("76Je", "BUO", true)]
	[InlineData("76Je", "", false)]
	[InlineData("", "BUO", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "eDabQ3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("tQq", "odI2d2", "QN4h", true)]
	[InlineData("tQq", "", "", false)]
	[InlineData("", "odI2d2", "QN4h", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier3(string dateTimeQualifier3, string date3, string time3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		subject.Date3 = date3;
		subject.Time3 = time3;
		//A Requires B
		if (date3 != "")
			subject.DateTimeQualifier3 = "tQq";
		if (time3 != "")
			subject.DateTimeQualifier3 = "tQq";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("odI2d2", "tQq", true)]
	[InlineData("odI2d2", "", false)]
	[InlineData("", "tQq", true)]
	public void Validation_ARequiresBDate3(string date3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Date3 = date3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QN4h", "tQq", true)]
	[InlineData("QN4h", "", false)]
	[InlineData("", "tQq", true)]
	public void Validation_ARequiresBTime3(string time3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Time3 = time3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3))
		{
			subject.Date3 = "odI2d2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("bQB", "uQxDad", "mtSZ", true)]
	[InlineData("bQB", "", "", false)]
	[InlineData("", "uQxDad", "mtSZ", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier4(string dateTimeQualifier4, string date4, string time4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		subject.Date4 = date4;
		subject.Time4 = time4;
		//A Requires B
		if (date4 != "")
			subject.DateTimeQualifier4 = "bQB";
		if (time4 != "")
			subject.DateTimeQualifier4 = "bQB";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uQxDad", "bQB", true)]
	[InlineData("uQxDad", "", false)]
	[InlineData("", "bQB", true)]
	public void Validation_ARequiresBDate4(string date4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Date4 = date4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mtSZ", "bQB", true)]
	[InlineData("mtSZ", "", false)]
	[InlineData("", "bQB", true)]
	public void Validation_ARequiresBTime4(string time4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Time4 = time4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4))
		{
			subject.Date4 = "uQxDad";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "DG4";
			subject.Date5 = "pWKW5v";
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("DG4", "pWKW5v", "f30X", true)]
	[InlineData("DG4", "", "", false)]
	[InlineData("", "pWKW5v", "f30X", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier5(string dateTimeQualifier5, string date5, string time5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		subject.Date5 = date5;
		subject.Time5 = time5;
		//A Requires B
		if (date5 != "")
			subject.DateTimeQualifier5 = "DG4";
		if (time5 != "")
			subject.DateTimeQualifier5 = "DG4";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pWKW5v", "DG4", true)]
	[InlineData("pWKW5v", "", false)]
	[InlineData("", "DG4", true)]
	public void Validation_ARequiresBDate5(string date5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Date5 = date5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.Time5 = "f30X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f30X", "DG4", true)]
	[InlineData("f30X", "", false)]
	[InlineData("", "DG4", true)]
	public void Validation_ARequiresBTime5(string time5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "Xc";
		subject.CurrencyCode = "841";
		//Test Parameters
		subject.Time5 = time5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "BUO";
			subject.Date2 = "eDabQ3";
			subject.Time2 = "76Je";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "tQq";
			subject.Date3 = "odI2d2";
			subject.Time3 = "QN4h";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "bQB";
			subject.Date4 = "uQxDad";
			subject.Time4 = "mtSZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5))
		{
			subject.Date5 = "pWKW5v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
