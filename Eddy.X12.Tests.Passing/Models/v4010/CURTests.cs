using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*mC*yKW*6864*EJ*PG8*tNr*O0W*JHIPHa2T*LB6R*TOu*LsJRKamc*u3Lb*IEi*gl8XawsU*3gCk*ncQ*Z0RUfbu2*xgdZ*UtT*MWHE6TrT*LRBC";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "mC",
			CurrencyCode = "yKW",
			ExchangeRate = 6864,
			EntityIdentifierCode2 = "EJ",
			CurrencyCode2 = "PG8",
			CurrencyMarketExchangeCode = "tNr",
			DateTimeQualifier = "O0W",
			Date = "JHIPHa2T",
			Time = "LB6R",
			DateTimeQualifier2 = "TOu",
			Date2 = "LsJRKamc",
			Time2 = "u3Lb",
			DateTimeQualifier3 = "IEi",
			Date3 = "gl8XawsU",
			Time3 = "3gCk",
			DateTimeQualifier4 = "ncQ",
			Date4 = "Z0RUfbu2",
			Time4 = "xgdZ",
			DateTimeQualifier5 = "UtT",
			Date5 = "MWHE6TrT",
			Time5 = "LRBC",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mC", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yKW", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JHIPHa2T", "O0W", true)]
	[InlineData("JHIPHa2T", "", false)]
	[InlineData("", "O0W", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LB6R", "O0W", true)]
	[InlineData("LB6R", "", false)]
	[InlineData("", "O0W", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("TOu", "LsJRKamc", "u3Lb", true)]
	[InlineData("TOu", "", "", false)]
	[InlineData("", "LsJRKamc", "u3Lb", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "TOu";
		if (time2 != "")
			subject.DateTimeQualifier2 = "TOu";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LsJRKamc", "TOu", true)]
	[InlineData("LsJRKamc", "", false)]
	[InlineData("", "TOu", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u3Lb", "TOu", true)]
	[InlineData("u3Lb", "", false)]
	[InlineData("", "TOu", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "LsJRKamc";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("IEi", "gl8XawsU", "3gCk", true)]
	[InlineData("IEi", "", "", false)]
	[InlineData("", "gl8XawsU", "3gCk", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier3(string dateTimeQualifier3, string date3, string time3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		subject.Date3 = date3;
		subject.Time3 = time3;
		//A Requires B
		if (date3 != "")
			subject.DateTimeQualifier3 = "IEi";
		if (time3 != "")
			subject.DateTimeQualifier3 = "IEi";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gl8XawsU", "IEi", true)]
	[InlineData("gl8XawsU", "", false)]
	[InlineData("", "IEi", true)]
	public void Validation_ARequiresBDate3(string date3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Date3 = date3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3gCk", "IEi", true)]
	[InlineData("3gCk", "", false)]
	[InlineData("", "IEi", true)]
	public void Validation_ARequiresBTime3(string time3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Time3 = time3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3))
		{
			subject.Date3 = "gl8XawsU";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("ncQ", "Z0RUfbu2", "xgdZ", true)]
	[InlineData("ncQ", "", "", false)]
	[InlineData("", "Z0RUfbu2", "xgdZ", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier4(string dateTimeQualifier4, string date4, string time4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		subject.Date4 = date4;
		subject.Time4 = time4;
		//A Requires B
		if (date4 != "")
			subject.DateTimeQualifier4 = "ncQ";
		if (time4 != "")
			subject.DateTimeQualifier4 = "ncQ";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z0RUfbu2", "ncQ", true)]
	[InlineData("Z0RUfbu2", "", false)]
	[InlineData("", "ncQ", true)]
	public void Validation_ARequiresBDate4(string date4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Date4 = date4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xgdZ", "ncQ", true)]
	[InlineData("xgdZ", "", false)]
	[InlineData("", "ncQ", true)]
	public void Validation_ARequiresBTime4(string time4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Time4 = time4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4))
		{
			subject.Date4 = "Z0RUfbu2";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "UtT";
			subject.Date5 = "MWHE6TrT";
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("UtT", "MWHE6TrT", "LRBC", true)]
	[InlineData("UtT", "", "", false)]
	[InlineData("", "MWHE6TrT", "LRBC", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier5(string dateTimeQualifier5, string date5, string time5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		subject.Date5 = date5;
		subject.Time5 = time5;
		//A Requires B
		if (date5 != "")
			subject.DateTimeQualifier5 = "UtT";
		if (time5 != "")
			subject.DateTimeQualifier5 = "UtT";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MWHE6TrT", "UtT", true)]
	[InlineData("MWHE6TrT", "", false)]
	[InlineData("", "UtT", true)]
	public void Validation_ARequiresBDate5(string date5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Date5 = date5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.Time5 = "LRBC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LRBC", "UtT", true)]
	[InlineData("LRBC", "", false)]
	[InlineData("", "UtT", true)]
	public void Validation_ARequiresBTime5(string time5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "mC";
		subject.CurrencyCode = "yKW";
		//Test Parameters
		subject.Time5 = time5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "TOu";
			subject.Date2 = "LsJRKamc";
			subject.Time2 = "u3Lb";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "IEi";
			subject.Date3 = "gl8XawsU";
			subject.Time3 = "3gCk";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "ncQ";
			subject.Date4 = "Z0RUfbu2";
			subject.Time4 = "xgdZ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5))
		{
			subject.Date5 = "MWHE6TrT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
