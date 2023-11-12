using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRC*Kfl*4Z*u*4*4*9*N*5*z*wx*4*";

		var expected = new PRC_PaymentRateChange()
		{
			DateTimeQualifier = "Kfl",
			DateTimePeriodFormatQualifier = "4Z",
			DateTimePeriod = "u",
			InterestRate = 4,
			InterestRate2 = 4,
			InterestRate3 = 9,
			AmountQualifierCode = "N",
			MonetaryAmount = 5,
			YesNoConditionOrResponseCode = "z",
			QuantityQualifier = "wx",
			Quantity = 4,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<PRC_PaymentRateChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kfl", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "4Z";
		subject.DateTimePeriod = "u";
		subject.InterestRate = 4;
		subject.InterestRate2 = 4;
		subject.InterestRate3 = 9;
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Z", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "Kfl";
		subject.DateTimePeriod = "u";
		subject.InterestRate = 4;
		subject.InterestRate2 = 4;
		subject.InterestRate3 = 9;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "Kfl";
		subject.DateTimePeriodFormatQualifier = "4Z";
		subject.InterestRate = 4;
		subject.InterestRate2 = 4;
		subject.InterestRate3 = 9;
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "Kfl";
		subject.DateTimePeriodFormatQualifier = "4Z";
		subject.DateTimePeriod = "u";
		subject.InterestRate2 = 4;
		subject.InterestRate3 = 9;
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredInterestRate2(decimal interestRate2, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "Kfl";
		subject.DateTimePeriodFormatQualifier = "4Z";
		subject.DateTimePeriod = "u";
		subject.InterestRate = 4;
		subject.InterestRate3 = 9;
		//Test Parameters
		if (interestRate2 > 0) 
			subject.InterestRate2 = interestRate2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredInterestRate3(decimal interestRate3, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "Kfl";
		subject.DateTimePeriodFormatQualifier = "4Z";
		subject.DateTimePeriod = "u";
		subject.InterestRate = 4;
		subject.InterestRate2 = 4;
		//Test Parameters
		if (interestRate3 > 0) 
			subject.InterestRate3 = interestRate3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("N", 5, true)]
	[InlineData("N", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PRC_PaymentRateChange();
		//Required fields
		subject.DateTimeQualifier = "Kfl";
		subject.DateTimePeriodFormatQualifier = "4Z";
		subject.DateTimePeriod = "u";
		subject.InterestRate = 4;
		subject.InterestRate2 = 4;
		subject.InterestRate3 = 9;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
