using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LV*6*e";

		var expected = new LV_LoanVerification()
		{
			AssignedNumber = 6,
			LoanVerificationCode = "e",
		};

		var actual = Map.MapObject<LV_LoanVerification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new LV_LoanVerification();
		subject.LoanVerificationCode = "e";
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredLoanVerificationCode(string loanVerificationCode, bool isValidExpected)
	{
		var subject = new LV_LoanVerification();
		subject.AssignedNumber = 6;
		subject.LoanVerificationCode = loanVerificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
