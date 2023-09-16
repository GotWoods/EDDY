using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SC*4*e";

		var expected = new SC_DocketSubLevel()
		{
			Level = 4,
			SubLevel = "e",
		};

		var actual = Map.MapObject<SC_DocketSubLevel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredLevel(int level, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.SubLevel = "e";
		if (level > 0)
			subject.Level = level;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredSubLevel(string subLevel, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.Level = 4;
		subject.SubLevel = subLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
