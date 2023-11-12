using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*oX*TB0*1321*Ft*Lae*KFx*pPJ*xF5ARl*wsV9*4Mr*lRRqd8*VrPB*ZvK*vCJDDg*6Y1o*7EA*qGhUm0*4d4p*uZk*inxAtk*LSCu";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "oX",
			CurrencyCode = "TB0",
			ExchangeRate = 1321,
			EntityIdentifierCode2 = "Ft",
			CurrencyCode2 = "Lae",
			CurrencyMarketExchangeCode = "KFx",
			DateTimeQualifier = "pPJ",
			Date = "xF5ARl",
			Time = "wsV9",
			DateTimeQualifier2 = "4Mr",
			Date2 = "lRRqd8",
			Time2 = "VrPB",
			DateTimeQualifier3 = "ZvK",
			Date3 = "vCJDDg",
			Time3 = "6Y1o",
			DateTimeQualifier4 = "7EA",
			Date4 = "qGhUm0",
			Time4 = "4d4p",
			DateTimeQualifier5 = "uZk",
			Date5 = "inxAtk",
			Time5 = "LSCu",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oX", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TB0", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xF5ARl", "pPJ", true)]
	[InlineData("xF5ARl", "", false)]
	[InlineData("", "pPJ", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wsV9", "pPJ", true)]
	[InlineData("wsV9", "", false)]
	[InlineData("", "pPJ", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("4Mr", "lRRqd8", "VrPB", true)]
	[InlineData("4Mr", "", "", false)]
	[InlineData("", "lRRqd8", "VrPB", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "4Mr";
		if (time2 != "")
			subject.DateTimeQualifier2 = "4Mr";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lRRqd8", "4Mr", true)]
	[InlineData("lRRqd8", "", false)]
	[InlineData("", "4Mr", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VrPB", "4Mr", true)]
	[InlineData("VrPB", "", false)]
	[InlineData("", "4Mr", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "lRRqd8";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("ZvK", "vCJDDg", "6Y1o", true)]
	[InlineData("ZvK", "", "", false)]
	[InlineData("", "vCJDDg", "6Y1o", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier3(string dateTimeQualifier3, string date3, string time3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		subject.Date3 = date3;
		subject.Time3 = time3;
		//A Requires B
		if (date3 != "")
			subject.DateTimeQualifier3 = "ZvK";
		if (time3 != "")
			subject.DateTimeQualifier3 = "ZvK";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vCJDDg", "ZvK", true)]
	[InlineData("vCJDDg", "", false)]
	[InlineData("", "ZvK", true)]
	public void Validation_ARequiresBDate3(string date3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Date3 = date3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6Y1o", "ZvK", true)]
	[InlineData("6Y1o", "", false)]
	[InlineData("", "ZvK", true)]
	public void Validation_ARequiresBTime3(string time3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Time3 = time3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3))
		{
			subject.Date3 = "vCJDDg";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("7EA", "qGhUm0", "4d4p", true)]
	[InlineData("7EA", "", "", false)]
	[InlineData("", "qGhUm0", "4d4p", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier4(string dateTimeQualifier4, string date4, string time4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		subject.Date4 = date4;
		subject.Time4 = time4;
		//A Requires B
		if (date4 != "")
			subject.DateTimeQualifier4 = "7EA";
		if (time4 != "")
			subject.DateTimeQualifier4 = "7EA";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qGhUm0", "7EA", true)]
	[InlineData("qGhUm0", "", false)]
	[InlineData("", "7EA", true)]
	public void Validation_ARequiresBDate4(string date4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Date4 = date4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4d4p", "7EA", true)]
	[InlineData("4d4p", "", false)]
	[InlineData("", "7EA", true)]
	public void Validation_ARequiresBTime4(string time4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Time4 = time4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4))
		{
			subject.Date4 = "qGhUm0";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "uZk";
			subject.Date5 = "inxAtk";
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("uZk", "inxAtk", "LSCu", true)]
	[InlineData("uZk", "", "", false)]
	[InlineData("", "inxAtk", "LSCu", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier5(string dateTimeQualifier5, string date5, string time5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		subject.Date5 = date5;
		subject.Time5 = time5;
		//A Requires B
		if (date5 != "")
			subject.DateTimeQualifier5 = "uZk";
		if (time5 != "")
			subject.DateTimeQualifier5 = "uZk";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("inxAtk", "uZk", true)]
	[InlineData("inxAtk", "", false)]
	[InlineData("", "uZk", true)]
	public void Validation_ARequiresBDate5(string date5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Date5 = date5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.Time5 = "LSCu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LSCu", "uZk", true)]
	[InlineData("LSCu", "", false)]
	[InlineData("", "uZk", true)]
	public void Validation_ARequiresBTime5(string time5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "oX";
		subject.CurrencyCode = "TB0";
		//Test Parameters
		subject.Time5 = time5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "4Mr";
			subject.Date2 = "lRRqd8";
			subject.Time2 = "VrPB";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "ZvK";
			subject.Date3 = "vCJDDg";
			subject.Time3 = "6Y1o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "7EA";
			subject.Date4 = "qGhUm0";
			subject.Time4 = "4d4p";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5))
		{
			subject.Date5 = "inxAtk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
