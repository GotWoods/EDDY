using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class STSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STS*9j*67feTg*r8Si*ql*92*7eK";

		var expected = new STS_InterchangeStatusSegment()
		{
			InterchangeActionCode = "9j",
			InterchangeActionDate = "67feTg",
			InterchangeActionTime = "r8Si",
			TimeCode = "ql",
			Century = 92,
			ErrorReasonCode = "7eK",
		};

		var actual = Map.MapObject<STS_InterchangeStatusSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9j", true)]
	public void Validation_RequiredInterchangeActionCode(string interchangeActionCode, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.InterchangeActionDate = "67feTg";
		subject.InterchangeActionTime = "r8Si";
		//Test Parameters
		subject.InterchangeActionCode = interchangeActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("67feTg", true)]
	public void Validation_RequiredInterchangeActionDate(string interchangeActionDate, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.InterchangeActionCode = "9j";
		subject.InterchangeActionTime = "r8Si";
		//Test Parameters
		subject.InterchangeActionDate = interchangeActionDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r8Si", true)]
	public void Validation_RequiredInterchangeActionTime(string interchangeActionTime, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		//Required fields
		subject.InterchangeActionCode = "9j";
		subject.InterchangeActionDate = "67feTg";
		//Test Parameters
		subject.InterchangeActionTime = interchangeActionTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
