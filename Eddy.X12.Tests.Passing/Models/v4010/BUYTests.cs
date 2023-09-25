using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BUYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BUY*4*j*8*3*1";

		var expected = new BUY_LoanBuydown()
		{
			LoanBuydownTypeCode = "4",
			BuydownSourceCode = "j",
			MonetaryAmount = 8,
			Percent = 3,
			Percent2 = 1,
		};

		var actual = Map.MapObject<BUY_LoanBuydown>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredLoanBuydownTypeCode(string loanBuydownTypeCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.BuydownSourceCode = "j";
		//Test Parameters
		subject.LoanBuydownTypeCode = loanBuydownTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredBuydownSourceCode(string buydownSourceCode, bool isValidExpected)
	{
		var subject = new BUY_LoanBuydown();
		//Required fields
		subject.LoanBuydownTypeCode = "4";
		//Test Parameters
		subject.BuydownSourceCode = buydownSourceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
