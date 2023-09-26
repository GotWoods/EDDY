using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRC*nYO*O7*D*7*4*3*o*7*X*IQ*4*";

		var expected = new PRC_PaymentRateChange()
		{
			DateTimeQualifier = "nYO",
			DateTimePeriodFormatQualifier = "O7",
			DateTimePeriod = "D",
			InterestRate = 7,
			InterestRate2 = 4,
			InterestRate3 = 3,
			AmountQualifierCode = "o",
			MonetaryAmount = 7,
			YesNoConditionOrResponseCode = "X",
			QuantityQualifier = "IQ",
			Quantity = 4,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<PRC_PaymentRateChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nYO", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "O7";
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "o";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O7", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "nYO";
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "o";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "nYO";
		subject.DateTimePeriodFormatQualifier = "O7";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "o";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("o", 7, true)]
	[InlineData("o", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "nYO";
		subject.DateTimePeriodFormatQualifier = "O7";
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
