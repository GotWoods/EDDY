using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLI*R*4*4*jT*31*B*1*2";

		var expected = new PLI_PreviousLoanInformation()
		{
			LoanTypeCode = "R",
			MonetaryAmount = 4,
			InterestRate = 4,
			LevelOfStudentOrTestCode = "jT",
			DateTimePeriodFormatQualifier = "31",
			DateTimePeriod = "B",
			MonetaryAmount2 = 1,
			Quantity = 2,
		};

		var actual = Map.MapObject<PLI_PreviousLoanInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.MonetaryAmount = 4;
		subject.InterestRate = 4;
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "31";
			subject.DateTimePeriod = "B";
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
		subject.LoanTypeCode = "R";
		subject.InterestRate = 4;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "31";
			subject.DateTimePeriod = "B";
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
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "31";
			subject.DateTimePeriod = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("31", "B", true)]
	[InlineData("31", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PLI_PreviousLoanInformation();
		//Required fields
		subject.LoanTypeCode = "R";
		subject.MonetaryAmount = 4;
		subject.InterestRate = 4;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
