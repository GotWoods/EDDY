using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class LVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LV*7*D";

		var expected = new LV_LoanVerification()
		{
			AssignedNumber = 7,
			LoanVerificationCode = "D",
		};

		var actual = Map.MapObject<LV_LoanVerification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new LV_LoanVerification();
		//Required fields
		subject.LoanVerificationCode = "D";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredLoanVerificationCode(string loanVerificationCode, bool isValidExpected)
	{
		var subject = new LV_LoanVerification();
		//Required fields
		subject.AssignedNumber = 7;
		//Test Parameters
		subject.LoanVerificationCode = loanVerificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
