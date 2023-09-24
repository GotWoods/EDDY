using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SBTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBT*dnFZn*U*p";

		var expected = new SBT_Subtest()
		{
			SubtestCode = "dnFZn",
			Name = "U",
			TestScoreInterpretationCode = "p",
		};

		var actual = Map.MapObject<SBT_Subtest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dnFZn", true)]
	public void Validation_RequiredSubtestCode(string subtestCode, bool isValidExpected)
	{
		var subject = new SBT_Subtest();
		subject.SubtestCode = subtestCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
