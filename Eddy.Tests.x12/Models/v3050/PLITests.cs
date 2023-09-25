using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLI*W*4*6*zt*8u*v*7*3*Z";

		var expected = new PLI_PreviousLoanInformation()
		{
			LoanTypeCode = "W",
			MonetaryAmount = 4,
			InterestRate = 6,
			LevelOfIndividualOrTestCode = "zt",
			DateTimePeriodFormatQualifier = "8u",
			DateTimePeriod = "v",
			MonetaryAmount2 = 7,
			Quantity = 3,
			LoanRateTypeCode = "Z",
		};

		var actual = Map.MapObject<PLI_PreviousLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.MonetaryAmount = 4;
		subject.InterestRate = 6;
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8u";
			subject.DateTimePeriod = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.LoanTypeCode = "W";
		subject.InterestRate = 6;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8u";
			subject.DateTimePeriod = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredInterestRate(decimal interestRate, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.LoanTypeCode = "W";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8u";
			subject.DateTimePeriod = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8u", "v", true)]
	[InlineData("8u", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.LoanTypeCode = "W";
		subject.MonetaryAmount = 4;
		subject.InterestRate = 6;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
