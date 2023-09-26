using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRC*jM4*Fe*i*3*9*8*7*7*b*kb*8*";

		var expected = new PRC_PaymentRateChange()
		{
			DateTimeQualifier = "jM4",
			DateTimePeriodFormatQualifier = "Fe",
			DateTimePeriod = "i",
			InterestRate = 3,
			InterestRate2 = 9,
			InterestRate3 = 8,
			AmountQualifierCode = "7",
			MonetaryAmount = 7,
			YesNoConditionOrResponseCode = "b",
			QuantityQualifier = "kb",
			Quantity = 8,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<PRC_PaymentRateChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jM4", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "Fe";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "7";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fe", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "jM4";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "7";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "jM4";
		subject.DateTimePeriodFormatQualifier = "Fe";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "7";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7", 7, true)]
	[InlineData("7", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "jM4";
		subject.DateTimePeriodFormatQualifier = "Fe";
		subject.DateTimePeriod = "i";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
