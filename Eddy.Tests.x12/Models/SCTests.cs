using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SC*8*p";

		var expected = new SC_DocketSubLevel()
		{
			DocketLevelNumber = 8,
			SubLevel = "p",
		};

		var actual = Map.MapObject<SC_DocketSubLevel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredDocketLevelNumber(int docketLevelNumber, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.SubLevel = "p";
		if (docketLevelNumber > 0)
		subject.DocketLevelNumber = docketLevelNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredSubLevel(string subLevel, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.DocketLevelNumber = 8;
		subject.SubLevel = subLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
