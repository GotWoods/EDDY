using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SRETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRE*8*D";

		var expected = new SRE_TestScores()
		{
			TestScoreQualifierCode = "8",
			Description = "D",
		};

		var actual = Map.MapObject<SRE_TestScores>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredTestScoreQualifierCode(string testScoreQualifierCode, bool isValidExpected)
	{
		var subject = new SRE_TestScores();
		subject.Description = "D";
		subject.TestScoreQualifierCode = testScoreQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new SRE_TestScores();
		subject.TestScoreQualifierCode = "8";
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
