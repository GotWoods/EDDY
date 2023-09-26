using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class STSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STS*0H*XkyJsC*tRyu*NX*h0H";

		var expected = new STS_InterchangeStatusSegment()
		{
			ActionCode = "0H",
			ActionDate = "XkyJsC",
			ActionTime = "tRyu",
			TimeCode = "NX",
			ErrorReasonCode = "h0H",
		};

		var actual = Map.MapObject<STS_InterchangeStatusSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0H", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.ActionDate = "XkyJsC";
		subject.ActionTime = "tRyu";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XkyJsC", true)]
	public void Validation_RequiredActionDate(string actionDate, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.ActionCode = "0H";
		subject.ActionTime = "tRyu";
		//Test Parameters
		subject.ActionDate = actionDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tRyu", true)]
	public void Validation_RequiredActionTime(string actionTime, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.ActionCode = "0H";
		subject.ActionDate = "XkyJsC";
		//Test Parameters
		subject.ActionTime = actionTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
