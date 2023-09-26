using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class IDBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDB*F*p*7*5*Q";

		var expected = new IDB_IndebtednessForStudentLoans()
		{
			LoanTypeCode = "F",
			AmountQualifierCode = "p",
			MonetaryAmount = 7,
			InterestRate = 5,
			LoanRateTypeCode = "Q",
		};

		var actual = Map.MapObject<IDB_IndebtednessForStudentLoans>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.AmountQualifierCode = "p";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.LoanTypeCode = loanTypeCode;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 5;
			subject.LoanRateTypeCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.LoanTypeCode = "F";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 5;
			subject.LoanRateTypeCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.LoanTypeCode = "F";
		subject.AmountQualifierCode = "p";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.InterestRate > 0 || subject.InterestRate > 0 || !string.IsNullOrEmpty(subject.LoanRateTypeCode))
		{
			subject.InterestRate = 5;
			subject.LoanRateTypeCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Q", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Q", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		//Required fields
		subject.LoanTypeCode = "F";
		subject.AmountQualifierCode = "p";
		subject.MonetaryAmount = 7;
		//Test Parameters
		if (interestRate > 0) 
			subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
