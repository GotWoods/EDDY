using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SRETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRE*s*X";

		var expected = new SRE_TestScores()
		{
			TestScoreQualifierCode = "s",
			Description = "X",
		};

		var actual = Map.MapObject<SRE_TestScores>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredTestScoreQualifierCode(string testScoreQualifierCode, bool isValidExpected)
	{
		var subject = new SRE_TestScores();
		//Required fields
		subject.Description = "X";
		//Test Parameters
		subject.TestScoreQualifierCode = testScoreQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new SRE_TestScores();
		//Required fields
		subject.TestScoreQualifierCode = "s";
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
