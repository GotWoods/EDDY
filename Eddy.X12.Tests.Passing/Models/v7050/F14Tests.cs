using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class F14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F14*4*Tvg";

		var expected = new F14_LineItemReject()
		{
			AssignedNumber = 4,
			DeclineAmendReasonCode = "Tvg",
		};

		var actual = Map.MapObject<F14_LineItemReject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F14_LineItemReject();
		subject.DeclineAmendReasonCode = "Tvg";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tvg", true)]
	public void Validation_RequiredDeclineAmendReasonCode(string declineAmendReasonCode, bool isValidExpected)
	{
		var subject = new F14_LineItemReject();
		subject.AssignedNumber = 4;
		subject.DeclineAmendReasonCode = declineAmendReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
