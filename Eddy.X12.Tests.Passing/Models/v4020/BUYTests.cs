using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BUYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BUY*8*F*8*4*4";

		var expected = new BUY_LoanBuydown()
		{
			LoanBuydownTypeCode = "8",
			SourceOfFundsCode = "F",
			MonetaryAmount = 8,
			Percent = 4,
			Percent2 = 4,
		};

		var actual = Map.MapObject<BUY_LoanBuydown>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredLoanBuydownTypeCode(string loanBuydownTypeCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.SourceOfFundsCode = "F";
		//Test Parameters
		subject.LoanBuydownTypeCode = loanBuydownTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredSourceOfFundsCode(string sourceOfFundsCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.LoanBuydownTypeCode = "8";
		//Test Parameters
		subject.SourceOfFundsCode = sourceOfFundsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
