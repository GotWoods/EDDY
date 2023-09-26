using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLI*N*7*4*KB*8F*9*7*9*U";

		var expected = new PLI_PreviousLoanInformation()
		{
			LoanTypeCode = "N",
			MonetaryAmount = 7,
			InterestRate = 4,
			LevelOfIndividualTestOrCourseCode = "KB",
			DateTimePeriodFormatQualifier = "8F",
			DateTimePeriod = "9",
			MonetaryAmount2 = 7,
			Quantity = 9,
			LoanRateTypeCode = "U",
		};

		var actual = Map.MapObject<PLI_PreviousLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.MonetaryAmount = 7;
		subject.InterestRate = 4;
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8F";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.LoanTypeCode = "N";
		subject.InterestRate = 4;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8F";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.LoanTypeCode = "N";
		subject.MonetaryAmount = 7;
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8F";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8F", "9", true)]
	[InlineData("8F", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.LoanTypeCode = "N";
		subject.MonetaryAmount = 7;
		subject.InterestRate = 4;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
