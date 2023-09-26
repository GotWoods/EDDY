using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LUCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LUC*Z*OW**4N";

		var expected = new LUC_LoanUnderwriting()
		{
			LoanDocumentationTypeCode = "Z",
			LoanPurposeCode = "OW",
			CompositeUseOfProceeds = null,
			RiskOfLossCode = "4N",
		};

		var actual = Map.MapObject<LUC_LoanUnderwriting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredLoanDocumentationTypeCode(string loanDocumentationTypeCode, bool isValidExpected)
	{
		var subject = new LUC_LoanUnderwriting();
		//Required fields
		subject.LoanPurposeCode = "OW";
		//Test Parameters
		subject.LoanDocumentationTypeCode = loanDocumentationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OW", true)]
	public void Validation_RequiredLoanPurposeCode(string loanPurposeCode, bool isValidExpected)
	{
		var subject = new LUC_LoanUnderwriting();
		//Required fields
		subject.LoanDocumentationTypeCode = "Z";
		//Test Parameters
		subject.LoanPurposeCode = loanPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
