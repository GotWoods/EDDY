using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BUYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BUY*C*q*9*6*6";

		var expected = new BUY_LoanBuydown()
		{
			LoanBuydownTypeCode = "C",
			BuydownSourceCode = "q",
			MonetaryAmount = 9,
			Percent = 6,
			Percent2 = 6,
		};

		var actual = Map.MapObject<BUY_LoanBuydown>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredLoanBuydownTypeCode(string loanBuydownTypeCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.BuydownSourceCode = "q";
		//Test Parameters
		subject.LoanBuydownTypeCode = loanBuydownTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredBuydownSourceCode(string buydownSourceCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.LoanBuydownTypeCode = "C";
		//Test Parameters
		subject.BuydownSourceCode = buydownSourceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
