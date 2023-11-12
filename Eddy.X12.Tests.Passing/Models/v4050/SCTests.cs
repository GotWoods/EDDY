using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SC*4*m";

		var expected = new SC_DocketSubLevel()
		{
			DocketLevelNumber = 4,
			SubLevel = "m",
		};

		var actual = Map.MapObject<SC_DocketSubLevel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredDocketLevelNumber(int docketLevelNumber, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.SubLevel = "m";
		if (docketLevelNumber > 0)
			subject.DocketLevelNumber = docketLevelNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredSubLevel(string subLevel, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.DocketLevelNumber = 4;
		subject.SubLevel = subLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
