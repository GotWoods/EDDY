using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BUYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BUY*0*X*9*6*7";

		var expected = new BUY_LoanBuydown()
		{
			LoanBuydownTypeCode = "0",
			SourceOfFundsCode = "X",
			MonetaryAmount = 9,
			PercentageAsDecimal = 6,
			PercentageAsDecimal2 = 7,
		};

		var actual = Map.MapObject<BUY_LoanBuydown>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredLoanBuydownTypeCode(string loanBuydownTypeCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		subject.SourceOfFundsCode = "X";
		subject.LoanBuydownTypeCode = loanBuydownTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validatation_RequiredSourceOfFundsCode(string sourceOfFundsCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		subject.LoanBuydownTypeCode = "0";
		subject.SourceOfFundsCode = sourceOfFundsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
