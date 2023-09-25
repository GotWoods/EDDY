using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class PAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAM*PJ*7**D*9*zU*KJo*CEwavt4n*hQVe*ZdX*BbZtgjq8*eNT9*R*1*u";

		var expected = new PAM_PeriodAmount()
		{
			QuantityQualifier = "PJ",
			Quantity = 7,
			CompositeUnitOfMeasure = null,
			AmountQualifierCode = "D",
			MonetaryAmount = 9,
			UnitOfTimePeriodOrIntervalCode = "zU",
			DateTimeQualifier = "KJo",
			Date = "CEwavt4n",
			Time = "hQVe",
			DateTimeQualifier2 = "ZdX",
			Date2 = "BbZtgjq8",
			Time2 = "eNT9",
			PercentQualifier = "R",
			PercentageAsDecimal = 1,
			YesNoConditionOrResponseCode = "u",
		};

		var actual = Map.MapObject<PAM_PeriodAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 9, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "KJo";
			subject.Date = "CEwavt4n";
			subject.Time = "hQVe";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ZdX";
			subject.Date2 = "BbZtgjq8";
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KJo", "zU", true)]
	[InlineData("KJo", "", false)]
	[InlineData("", "zU", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ZdX";
			subject.Date2 = "BbZtgjq8";
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("KJo", "CEwavt4n", "hQVe", true)]
	[InlineData("KJo", "", "", false)]
	[InlineData("", "CEwavt4n", "hQVe", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier(string dateTimeQualifier, string date, string time, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		subject.Time = time;
		//A Requires B
		if (date != "")
			subject.DateTimeQualifier = "KJo";
		if (time != "")
			subject.DateTimeQualifier = "KJo";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ZdX";
			subject.Date2 = "BbZtgjq8";
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CEwavt4n", "KJo", true)]
	[InlineData("CEwavt4n", "", false)]
	[InlineData("", "KJo", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrIntervalCode = "zU";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Time = "hQVe";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ZdX";
			subject.Date2 = "BbZtgjq8";
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hQVe", "KJo", true)]
	[InlineData("hQVe", "", false)]
	[InlineData("", "KJo", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrIntervalCode = "zU";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.Date = "CEwavt4n";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ZdX";
			subject.Date2 = "BbZtgjq8";
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZdX", "KJo", true)]
	[InlineData("ZdX", "", false)]
	[InlineData("", "KJo", true)]
	public void Validation_ARequiresBDateTimeQualifier2(string dateTimeQualifier2, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrIntervalCode = "zU";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "CEwavt4n";
			subject.Time = "hQVe";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("ZdX", "BbZtgjq8", "eNT9", true)]
	[InlineData("ZdX", "", "", false)]
	[InlineData("", "BbZtgjq8", "eNT9", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "ZdX";
		if (time2 != "")
			subject.DateTimeQualifier2 = "ZdX";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "KJo";
			subject.Date = "CEwavt4n";
			subject.Time = "hQVe";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BbZtgjq8", "ZdX", true)]
	[InlineData("BbZtgjq8", "", false)]
	[InlineData("", "ZdX", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "KJo";
			subject.Date = "CEwavt4n";
			subject.Time = "hQVe";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eNT9", "ZdX", true)]
	[InlineData("eNT9", "", false)]
	[InlineData("", "ZdX", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//A Requires B
		if (dateTimeQualifier2 != "")
			subject.DateTimeQualifier = "KJo";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "KJo";
			subject.Date = "CEwavt4n";
			subject.Time = "hQVe";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "BbZtgjq8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("R", 1, true)]
	[InlineData("R", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "KJo";
			subject.Date = "CEwavt4n";
			subject.Time = "hQVe";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ZdX";
			subject.Date2 = "BbZtgjq8";
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("u", 9, true)]
	[InlineData("u", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "D";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "R";
			subject.PercentageAsDecimal = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "KJo";
			subject.Date = "CEwavt4n";
			subject.Time = "hQVe";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "ZdX";
			subject.Date2 = "BbZtgjq8";
			subject.Time2 = "eNT9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
