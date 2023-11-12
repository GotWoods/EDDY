using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class IDBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDB*8*Q*5*2*J";

		var expected = new IDB_IndebtednessForStudentLoans()
		{
			LoanTypeCode = "8",
			AmountQualifierCode = "Q",
			MonetaryAmount = 5,
			InterestRate = 2,
			LoanRateTypeCode = "J",
		};

		var actual = Map.MapObject<IDB_IndebtednessForStudentLoans>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.AmountQualifierCode = "Q";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 2;
			subject.LoanRateTypeCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.LoanTypeCode = "8";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 2;
			subject.LoanRateTypeCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.LoanTypeCode = "8";
		subject.AmountQualifierCode = "Q";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 2;
			subject.LoanRateTypeCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "J", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "J", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.LoanTypeCode = "8";
		subject.AmountQualifierCode = "Q";
		subject.MonetaryAmount = 5;
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
