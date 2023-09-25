using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class BUYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BUY*t*J*8*3*9";

		var expected = new BUY_LoanBuydown()
		{
			LoanBuydownTypeCode = "t",
			SourceOfFundsCode = "J",
			MonetaryAmount = 8,
			PercentageAsDecimal = 3,
			PercentageAsDecimal2 = 9,
		};

		var actual = Map.MapObject<BUY_LoanBuydown>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredLoanBuydownTypeCode(string loanBuydownTypeCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.SourceOfFundsCode = "J";
		//Test Parameters
		subject.LoanBuydownTypeCode = loanBuydownTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredSourceOfFundsCode(string sourceOfFundsCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.LoanBuydownTypeCode = "t";
		//Test Parameters
		subject.SourceOfFundsCode = sourceOfFundsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
