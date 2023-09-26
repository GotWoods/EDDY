using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LV*2*J";

		var expected = new LV_LoanVerification()
		{
			AssignedNumber = 2,
			LoanVerificationCode = "J",
		};

		var actual = Map.MapObject<LV_LoanVerification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new LV_LoanVerification();
		//Required fields
		subject.LoanVerificationCode = "J";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredLoanVerificationCode(string loanVerificationCode, bool isValidExpected)
	{
		var subject = new LV_LoanVerification();
		//Required fields
		subject.AssignedNumber = 2;
		//Test Parameters
		subject.LoanVerificationCode = loanVerificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
