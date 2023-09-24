using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class STSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STS*Md*2VejG0*UKUK*Yl*TbO";

		var expected = new STS_InterchangeStatusSegment()
		{
			InterchangeActionCode = "Md",
			InterchangeActionDate = "2VejG0",
			InterchangeActionTime = "UKUK",
			TimeCode = "Yl",
			ErrorReasonCode = "TbO",
		};

		var actual = Map.MapObject<STS_InterchangeStatusSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Md", true)]
	public void Validation_RequiredInterchangeActionCode(string interchangeActionCode, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		subject.InterchangeActionDate = "2VejG0";
		subject.InterchangeActionTime = "UKUK";
		subject.InterchangeActionCode = interchangeActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2VejG0", true)]
	public void Validation_RequiredInterchangeActionDate(string interchangeActionDate, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		subject.InterchangeActionCode = "Md";
		subject.InterchangeActionTime = "UKUK";
		subject.InterchangeActionDate = interchangeActionDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UKUK", true)]
	public void Validation_RequiredInterchangeActionTime(string interchangeActionTime, bool isValidExpected)
	{
		var subject = new STS_InterchangeStatusSegment();
		subject.InterchangeActionCode = "Md";
		subject.InterchangeActionDate = "2VejG0";
		subject.InterchangeActionTime = interchangeActionTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
