using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PDLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDL*q0a*A*5*4*I*k*hM*4B6*z*u*OG*G";

		var expected = new PDL_PaymentDetails()
		{
			PaymentMethodCode = "q0a",
			AmountQualifierCode = "A",
			MonetaryAmount = 5,
			PercentageAsDecimal = 4,
			CreditDebitFlagCode = "I",
			FrequencyCode = "k",
			DFIIDNumberQualifier = "hM",
			DFIIdentificationNumber = "4B6",
			AccountNumberQualifier = "z",
			AccountNumber = "u",
			DateTimePeriodFormatQualifier = "OG",
			DateTimePeriod = "G",
		};

		var actual = Map.MapObject<PDL_PaymentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q0a", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		subject.PaymentMethodCode = paymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("A", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("A", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		subject.PaymentMethodCode = "q0a";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 4, false)]
	[InlineData(0, 4, true)]
	[InlineData(5, 0, true)]
	public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		subject.PaymentMethodCode = "q0a";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("hM", "4B6", true)]
	[InlineData("", "4B6", false)]
	[InlineData("hM", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		subject.PaymentMethodCode = "q0a";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("z", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("z", "", false)]
	public void Validation_AllAreRequiredAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		subject.PaymentMethodCode = "q0a";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("OG", "G", true)]
	[InlineData("", "G", false)]
	[InlineData("OG", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		subject.PaymentMethodCode = "q0a";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
