using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAM*Aa*4**O*8*b7*scN*l9Xv3871*0x0M*60J*fgTE2CfP*KV0s*X*7*R";

		var expected = new PAM_PeriodAmount()
		{
			QuantityQualifier = "Aa",
			Quantity = 4,
			CompositeUnitOfMeasure = null,
			AmountQualifierCode = "O",
			MonetaryAmount = 8,
			UnitOfTimePeriodOrInterval = "b7",
			DateTimeQualifier = "scN",
			Date = "l9Xv3871",
			Time = "0x0M",
			DateTimeQualifier2 = "60J",
			Date2 = "fgTE2CfP",
			Time2 = "KV0s",
			PercentQualifier = "X",
			Percent = 7,
			YesNoConditionOrResponseCode = "R",
		};

		var actual = Map.MapObject<PAM_PeriodAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O", 8, true)]
	[InlineData("O", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "b7";
			subject.DateTimeQualifier = "scN";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "X";
			subject.Percent = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "scN";
			subject.Date = "l9Xv3871";
			subject.Time = "0x0M";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "60J";
			subject.Date2 = "fgTE2CfP";
			subject.Time2 = "KV0s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b7", "scN", true)]
	[InlineData("b7", "", false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.DateTimeQualifier = dateTimeQualifier;
		
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "X";
			subject.Percent = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "l9Xv3871";
			subject.Time = "0x0M";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "60J";
			subject.Date2 = "fgTE2CfP";
			subject.Time2 = "KV0s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("scN", "l9Xv3871", "0x0M", true)]
	[InlineData("scN", "", "", false)]
	[InlineData("", "l9Xv3871", "0x0M", true)]
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
			subject.DateTimeQualifier = "scN";
		if (time != "")
			subject.DateTimeQualifier = "scN";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "b7";
			subject.DateTimeQualifier = "scN";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "X";
			subject.Percent = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "60J";
			subject.Date2 = "fgTE2CfP";
			subject.Time2 = "KV0s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l9Xv3871", "scN", true)]
	[InlineData("l9Xv3871", "", false)]
	[InlineData("", "scN", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrInterval = "b7";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "b7";
			subject.DateTimeQualifier = "scN";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "X";
			subject.Percent = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Time = "0x0M";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "60J";
			subject.Date2 = "fgTE2CfP";
			subject.Time2 = "KV0s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0x0M", "scN", true)]
	[InlineData("0x0M", "", false)]
	[InlineData("", "scN", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrInterval = "b7";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "b7";
			subject.DateTimeQualifier = "scN";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "X";
			subject.Percent = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.Date = "l9Xv3871";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "60J";
			subject.Date2 = "fgTE2CfP";
			subject.Time2 = "KV0s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("60J", "fgTE2CfP", "KV0s", true)]
	[InlineData("60J", "", "", false)]
	[InlineData("", "fgTE2CfP", "KV0s", true)]
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
			subject.DateTimeQualifier2 = "60J";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "b7";
			subject.DateTimeQualifier = "scN";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "X";
			subject.Percent = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "scN";
			subject.Date = "l9Xv3871";
			subject.Time = "0x0M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fgTE2CfP", "60J", true)]
	[InlineData("fgTE2CfP", "", false)]
	[InlineData("", "60J", true)]
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
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "b7";
			subject.DateTimeQualifier = "scN";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "X";
			subject.Percent = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "scN";
			subject.Date = "l9Xv3871";
			subject.Time = "0x0M";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "KV0s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 7, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "b7";
			subject.DateTimeQualifier = "scN";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "scN";
			subject.Date = "l9Xv3871";
			subject.Time = "0x0M";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "60J";
			subject.Date2 = "fgTE2CfP";
			subject.Time2 = "KV0s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
