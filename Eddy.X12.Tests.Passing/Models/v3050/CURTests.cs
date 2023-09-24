using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CUR*N1*mPB*6117*ws*hWl*Owe*BJP*Wzy9tZ*47If*ekf*x7eMP8*9BLx*Gp9*maqH5N*xvQ6*UQz*roDj4J*ZoMC*rhN*nhiwtZ*lB3N";

		var expected = new CUR_Currency()
		{
			EntityIdentifierCode = "N1",
			CurrencyCode = "mPB",
			ExchangeRate = 6117,
			EntityIdentifierCode2 = "ws",
			CurrencyCode2 = "hWl",
			CurrencyMarketExchangeCode = "Owe",
			DateTimeQualifier = "BJP",
			Date = "Wzy9tZ",
			Time = "47If",
			DateTimeQualifier2 = "ekf",
			Date2 = "x7eMP8",
			Time2 = "9BLx",
			DateTimeQualifier3 = "Gp9",
			Date3 = "maqH5N",
			Time3 = "xvQ6",
			DateTimeQualifier4 = "UQz",
			Date4 = "roDj4J",
			Time4 = "ZoMC",
			DateTimeQualifier5 = "rhN",
			Date5 = "nhiwtZ",
			Time5 = "lB3N",
		};

		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N1", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mPB", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Wzy9tZ", "BJP", true)]
	[InlineData("Wzy9tZ", "", false)]
	[InlineData("", "BJP", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("47If", "BJP", true)]
	[InlineData("47If", "", false)]
	[InlineData("", "BJP", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("ekf", "x7eMP8", "9BLx", true)]
	[InlineData("ekf", "", "", false)]
	[InlineData("", "x7eMP8", "9BLx", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "ekf";
		if (time2 != "")
			subject.DateTimeQualifier2 = "ekf";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x7eMP8", "ekf", true)]
	[InlineData("x7eMP8", "", false)]
	[InlineData("", "ekf", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9BLx", "ekf", true)]
	[InlineData("9BLx", "", false)]
	[InlineData("", "ekf", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "x7eMP8";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Gp9", "maqH5N", "xvQ6", true)]
	[InlineData("Gp9", "", "", false)]
	[InlineData("", "maqH5N", "xvQ6", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier3(string dateTimeQualifier3, string date3, string time3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		subject.Date3 = date3;
		subject.Time3 = time3;
		//A Requires B
		if (date3 != "")
			subject.DateTimeQualifier3 = "Gp9";
		if (time3 != "")
			subject.DateTimeQualifier3 = "Gp9";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("maqH5N", "Gp9", true)]
	[InlineData("maqH5N", "", false)]
	[InlineData("", "Gp9", true)]
	public void Validation_ARequiresBDate3(string date3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Date3 = date3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xvQ6", "Gp9", true)]
	[InlineData("xvQ6", "", false)]
	[InlineData("", "Gp9", true)]
	public void Validation_ARequiresBTime3(string time3, string dateTimeQualifier3, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Time3 = time3;
		subject.DateTimeQualifier3 = dateTimeQualifier3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3))
		{
			subject.Date3 = "maqH5N";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("UQz", "roDj4J", "ZoMC", true)]
	[InlineData("UQz", "", "", false)]
	[InlineData("", "roDj4J", "ZoMC", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier4(string dateTimeQualifier4, string date4, string time4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		subject.Date4 = date4;
		subject.Time4 = time4;
		//A Requires B
		if (date4 != "")
			subject.DateTimeQualifier4 = "UQz";
		if (time4 != "")
			subject.DateTimeQualifier4 = "UQz";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("roDj4J", "UQz", true)]
	[InlineData("roDj4J", "", false)]
	[InlineData("", "UQz", true)]
	public void Validation_ARequiresBDate4(string date4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Date4 = date4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZoMC", "UQz", true)]
	[InlineData("ZoMC", "", false)]
	[InlineData("", "UQz", true)]
	public void Validation_ARequiresBTime4(string time4, string dateTimeQualifier4, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Time4 = time4;
		subject.DateTimeQualifier4 = dateTimeQualifier4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4))
		{
			subject.Date4 = "roDj4J";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.DateTimeQualifier5 = "rhN";
			subject.Date5 = "nhiwtZ";
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("rhN", "nhiwtZ", "lB3N", true)]
	[InlineData("rhN", "", "", false)]
	[InlineData("", "nhiwtZ", "lB3N", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier5(string dateTimeQualifier5, string date5, string time5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		subject.Date5 = date5;
		subject.Time5 = time5;
		//A Requires B
		if (date5 != "")
			subject.DateTimeQualifier5 = "rhN";
		if (time5 != "")
			subject.DateTimeQualifier5 = "rhN";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nhiwtZ", "rhN", true)]
	[InlineData("nhiwtZ", "", false)]
	[InlineData("", "rhN", true)]
	public void Validation_ARequiresBDate5(string date5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Date5 = date5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Time5))
		{
			subject.Time5 = "lB3N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lB3N", "rhN", true)]
	[InlineData("lB3N", "", false)]
	[InlineData("", "rhN", true)]
	public void Validation_ARequiresBTime5(string time5, string dateTimeQualifier5, bool isValidExpected)
	{
		var subject = new CUR_Currency();
		//Required fields
		subject.EntityIdentifierCode = "N1";
		subject.CurrencyCode = "mPB";
		//Test Parameters
		subject.Time5 = time5;
		subject.DateTimeQualifier5 = dateTimeQualifier5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ekf";
			subject.Date2 = "x7eMP8";
			subject.Time2 = "9BLx";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.DateTimeQualifier3) || !string.IsNullOrEmpty(subject.Date3) || !string.IsNullOrEmpty(subject.Time3))
		{
			subject.DateTimeQualifier3 = "Gp9";
			subject.Date3 = "maqH5N";
			subject.Time3 = "xvQ6";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.DateTimeQualifier4) || !string.IsNullOrEmpty(subject.Date4) || !string.IsNullOrEmpty(subject.Time4))
		{
			subject.DateTimeQualifier4 = "UQz";
			subject.Date4 = "roDj4J";
			subject.Time4 = "ZoMC";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier5) || !string.IsNullOrEmpty(subject.Date5))
		{
			subject.Date5 = "nhiwtZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
