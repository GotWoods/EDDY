using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRC*dST*qf*L*4*5*6*7*5*T*0f*8*";

		var expected = new PRC_PaymentRateChange()
		{
			DateTimeQualifier = "dST",
			DateTimePeriodFormatQualifier = "qf",
			DateTimePeriod = "L",
			InterestRate = 4,
			InterestRate2 = 5,
			InterestRate3 = 6,
			AmountQualifierCode = "7",
			MonetaryAmount = 5,
			YesNoConditionOrResponseCode = "T",
			QuantityQualifier = "0f",
			Quantity = 8,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<PRC_PaymentRateChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dST", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		subject.DateTimePeriodFormatQualifier = "qf";
		subject.DateTimePeriod = "L";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qf", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		subject.DateTimeQualifier = "dST";
		subject.DateTimePeriod = "L";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		subject.DateTimeQualifier = "dST";
		subject.DateTimePeriodFormatQualifier = "qf";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("7", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("7", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		subject.DateTimeQualifier = "dST";
		subject.DateTimePeriodFormatQualifier = "qf";
		subject.DateTimePeriod = "L";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
