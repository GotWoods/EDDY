using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLI*S*6*6*6p*Fy*k*3*1*T";

		var expected = new PLI_PreviousLoanInformation()
		{
			LoanTypeCode = "S",
			MonetaryAmount = 6,
			InterestRate = 6,
			LevelOfIndividualTestOrCourseCode = "6p",
			DateTimePeriodFormatQualifier = "Fy",
			DateTimePeriod = "k",
			MonetaryAmount2 = 3,
			Quantity = 1,
			LoanRateTypeCode = "T",
		};

		var actual = Map.MapObject<PLI_PreviousLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		subject.MonetaryAmount = 6;
		subject.InterestRate = 6;
		subject.LoanTypeCode = loanTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		subject.LoanTypeCode = "S";
		subject.InterestRate = 6;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		subject.LoanTypeCode = "S";
		subject.MonetaryAmount = 6;
		if (interestRate > 0)
		subject.InterestRate = interestRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Fy", "k", true)]
	[InlineData("", "k", false)]
	[InlineData("Fy", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		subject.LoanTypeCode = "S";
		subject.MonetaryAmount = 6;
		subject.InterestRate = 6;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
