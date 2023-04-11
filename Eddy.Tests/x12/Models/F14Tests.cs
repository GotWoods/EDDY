using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F14*1*IFK";

		var expected = new F14_LineItemReject()
		{
			AssignedNumber = 1,
			DeclineAmendReasonCode = "IFK",
		};

		var actual = Map.MapObject<F14_LineItemReject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validatation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F14_LineItemReject();
		subject.DeclineAmendReasonCode = "IFK";
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IFK", true)]
	public void Validatation_RequiredDeclineAmendReasonCode(string declineAmendReasonCode, bool isValidExpected)
	{
		var subject = new F14_LineItemReject();
		subject.AssignedNumber = 1;
		subject.DeclineAmendReasonCode = declineAmendReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
