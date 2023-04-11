using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IDBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDB*2*w*2*2*p";

		var expected = new IDB_IndebtednessForStudentLoans()
		{
			LoanTypeCode = "2",
			AmountQualifierCode = "w",
			MonetaryAmount = 2,
			InterestRate = 2,
			LoanRateTypeCode = "p",
		};

		var actual = Map.MapObject<IDB_IndebtednessForStudentLoans>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredLoanTypeCode(string loanTypeCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		subject.AmountQualifierCode = "w";
		subject.MonetaryAmount = 2;
		subject.LoanTypeCode = loanTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		subject.LoanTypeCode = "2";
		subject.MonetaryAmount = 2;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		subject.LoanTypeCode = "2";
		subject.AmountQualifierCode = "w";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "p", true)]
	[InlineData(0, "p", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredInterestRate(decimal interestRate, string loanRateTypeCode, bool isValidExpected)
	{
		var subject = new IDB_IndebtednessForStudentLoans();
		subject.LoanTypeCode = "2";
		subject.AmountQualifierCode = "w";
		subject.MonetaryAmount = 2;
		if (interestRate > 0)
		subject.InterestRate = interestRate;
		subject.LoanRateTypeCode = loanRateTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
