using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAM*Ne*7**p*7*f7*8WE*FULFv9Fd*mTGn*aeq*M8qCdTWR*kfSw*Y*7*N";

		var expected = new PAM_PeriodAmount()
		{
			QuantityQualifier = "Ne",
			Quantity = 7,
			CompositeUnitOfMeasure = null,
			AmountQualifierCode = "p",
			MonetaryAmount = 7,
			UnitOfTimePeriodOrIntervalCode = "f7",
			DateTimeQualifier = "8WE",
			Date = "FULFv9Fd",
			Time = "mTGn",
			DateTimeQualifier2 = "aeq",
			Date2 = "M8qCdTWR",
			Time2 = "kfSw",
			PercentQualifier = "Y",
			PercentageAsDecimal = 7,
			YesNoConditionOrResponseCode = "N",
		};

		var actual = Map.MapObject<PAM_PeriodAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("p", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("p", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "f7", true)]
	[InlineData("8WE", "", false)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", "",true)]
	[InlineData("8WE", "FULFv9Fd","", false)]
	[InlineData("", "FULFv9Fd", "", true)]
	[InlineData("8WE", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier(string dateTimeQualifier, string date, string time, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "8WE", true)]
	[InlineData("FULFv9Fd", "", false)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;

		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrIntervalCode = "AA";

		if (dateTimeQualifier != "")
			subject.Time = "1234";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "8WE", true)]
	[InlineData("mTGn", "", false)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "8WE", true)]
	[InlineData("aeq", "", false)]
	public void Validation_ARequiresBDateTimeQualifier2(string dateTimeQualifier2, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.DateTimeQualifier = dateTimeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("aeq", "M8qCdTWR", "", false)]
	[InlineData("", "M8qCdTWR", "", true)]
	[InlineData("aeq", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "aeq", true)]
	[InlineData("M8qCdTWR", "", false)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;


		if (dateTimeQualifier2 != "")
		{
			subject.DateTimeQualifier = dateTimeQualifier2;
			subject.Time = "1234";
			subject.UnitOfTimePeriodOrIntervalCode = "AA";
		}

        if (dateTimeQualifier2 != "")
            subject.Time2 = "1234";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "aeq", true)]
	[InlineData("kfSw", "", false)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Y", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("Y", 0, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 7, true)]
	[InlineData("N", 0, false)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
