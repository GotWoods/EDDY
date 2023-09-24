using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLI*h*6*5*4*J*SS*d*s*K*Cb*S*xl*n*1*1*8*3*a*C*1I*B*e";

		var expected = new SLI_SpecificLoanInformation()
		{
			LoanTypeCode = "h",
			MonetaryAmount = 6,
			MonetaryAmount2 = 5,
			InterestRate = 4,
			LoanRateTypeCode = "J",
			DateTimePeriodFormatQualifier = "SS",
			DateTimePeriod = "d",
			ReferenceIdentification = "s",
			YesNoConditionOrResponseCode = "K",
			DateTimePeriodFormatQualifier2 = "Cb",
			DateTimePeriod2 = "S",
			DateTimePeriodFormatQualifier3 = "xl",
			DateTimePeriod3 = "n",
			MonetaryAmount3 = 1,
			Quantity = 1,
			Quantity2 = 8,
			Quantity3 = 3,
			YesNoConditionOrResponseCode2 = "a",
			YesNoConditionOrResponseCode3 = "C",
			DateTimePeriodFormatQualifier4 = "1I",
			DateTimePeriod4 = "B",
			PaymentMethodTypeCode = "e",
		};

		var actual = Map.MapObject<SLI_SpecificLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		subject.LoanTypeCode = loanTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		if (interestRate > 0)
		subject.InterestRate = interestRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredLoanRateTypeCode(string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		subject.LoanRateTypeCode = loanRateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SS", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriod = "d";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Cb", "S", true)]
	[InlineData("", "S", false)]
	[InlineData("Cb", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("xl", "n", true)]
	[InlineData("", "n", false)]
	[InlineData("xl", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("1I", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("1I", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new SLI_SpecificLoanInformation();
		subject.LoanTypeCode = "h";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 5;
		subject.InterestRate = 4;
		subject.LoanRateTypeCode = "J";
		subject.DateTimePeriodFormatQualifier = "SS";
		subject.DateTimePeriod = "d";
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
