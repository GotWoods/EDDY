using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F14*3*fUK";

		var expected = new F14_LineItemReject()
		{
			AssignedNumber = 3,
			DeclineAmendReasonCode = "fUK",
		};

		var actual = Map.MapObject<F14_LineItemReject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F14_LineItemReject();
		subject.DeclineAmendReasonCode = "fUK";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fUK", true)]
	public void Validation_RequiredDeclineAmendReasonCode(string declineAmendReasonCode, bool isValidExpected)
	{
		var subject = new F14_LineItemReject();
		subject.AssignedNumber = 3;
		subject.DeclineAmendReasonCode = declineAmendReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
