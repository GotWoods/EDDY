using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class STSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STS*OT*s5feaw*pIVL*R6*YpO";

		var expected = new STS_InterchangeStatusSegment()
		{
			InterchangeActionCode = "OT",
			InterchangeActionDate = "s5feaw",
			InterchangeActionTime = "pIVL",
			TimeCode = "R6",
			ErrorReasonCode = "YpO",
		};

		var actual = Map.MapObject<STS_InterchangeStatusSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OT", true)]
	public void Validation_RequiredInterchangeActionCode(string interchangeActionCode, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.InterchangeActionDate = "s5feaw";
		subject.InterchangeActionTime = "pIVL";
		//Test Parameters
		subject.InterchangeActionCode = interchangeActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s5feaw", true)]
	public void Validation_RequiredInterchangeActionDate(string interchangeActionDate, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.InterchangeActionCode = "OT";
		subject.InterchangeActionTime = "pIVL";
		//Test Parameters
		subject.InterchangeActionDate = interchangeActionDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pIVL", true)]
	public void Validation_RequiredInterchangeActionTime(string interchangeActionTime, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.InterchangeActionCode = "OT";
		subject.InterchangeActionDate = "s5feaw";
		//Test Parameters
		subject.InterchangeActionTime = interchangeActionTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
