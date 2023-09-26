using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SBTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBT*rllUc*O*c";

		var expected = new SBT_Subtest()
		{
			SubtestCode = "rllUc",
			Name = "O",
			TestScoreInterpretationCode = "c",
		};

		var actual = Map.MapObject<SBT_Subtest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rllUc", true)]
	public void Validation_RequiredSubtestCode(string subtestCode, bool isValidExpected)
	{
		var subject = new SBT_Subtest();
		//Required fields
		//Test Parameters
		subject.SubtestCode = subtestCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
