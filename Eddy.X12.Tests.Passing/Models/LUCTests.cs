using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LUCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LUC*0*D6**wV";

		var expected = new LUC_LoanUnderwriting()
		{
			LoanDocumentationTypeCode = "0",
			LoanPurposeCode = "D6",
			CompositeUseOfProceeds = null,
			RiskOfLossCode = "wV",
		};

		var actual = Map.MapObject<LUC_LoanUnderwriting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredLoanDocumentationTypeCode(string loanDocumentationTypeCode, bool isValidExpected)
	{
		var subject = new LUC_LoanUnderwriting();
		subject.LoanPurposeCode = "D6";
		subject.LoanDocumentationTypeCode = loanDocumentationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D6", true)]
	public void Validation_RequiredLoanPurposeCode(string loanPurposeCode, bool isValidExpected)
	{
		var subject = new LUC_LoanUnderwriting();
		subject.LoanDocumentationTypeCode = "0";
		subject.LoanPurposeCode = loanPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
