using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SRETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRE*z*U";

		var expected = new SRE_TestScores()
		{
			TestScoreQualifierCode = "z",
			FreeFormMessage = "U",
		};

		var actual = Map.MapObject<SRE_TestScores>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredTestScoreQualifierCode(string testScoreQualifierCode, bool isValidExpected)
	{
		var subject = new SRE_TestScores();
		//Required fields
		subject.FreeFormMessage = "U";
		//Test Parameters
		subject.TestScoreQualifierCode = testScoreQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredFreeFormMessage(string freeFormMessage, bool isValidExpected)
	{
		var subject = new SRE_TestScores();
		//Required fields
		subject.TestScoreQualifierCode = "z";
		//Test Parameters
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
