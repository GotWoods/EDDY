using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class STSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STS*wB*wLrVEo*nO1Q*oR*48*9CF";

		var expected = new STS_InterchangeStatusSegment()
		{
			ActionCode = "wB",
			ActionDate = "wLrVEo",
			ActionTime = "nO1Q",
			TimeCode = "oR",
			Century = 48,
			ErrorReasonCode = "9CF",
		};

		var actual = Map.MapObject<STS_InterchangeStatusSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wB", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.ActionDate = "wLrVEo";
		subject.ActionTime = "nO1Q";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wLrVEo", true)]
	public void Validation_RequiredActionDate(string actionDate, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.ActionCode = "wB";
		subject.ActionTime = "nO1Q";
		//Test Parameters
		subject.ActionDate = actionDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nO1Q", true)]
	public void Validation_RequiredActionTime(string actionTime, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.ActionCode = "wB";
		subject.ActionDate = "wLrVEo";
		//Test Parameters
		subject.ActionTime = actionTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
