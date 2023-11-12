using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SC*4*h*7";

		var expected = new SC_DocketSubLevel()
		{
			Level = 4,
			SubLevel = "h",
			AssignedNumber = 7,
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
		subject.SubLevel = "h";
		subject.AssignedNumber = 7;
		if (level > 0)
			subject.Level = level;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredSubLevel(string subLevel, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.Level = 4;
		subject.AssignedNumber = 7;
		subject.SubLevel = subLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new SC_DocketSubLevel();
		subject.Level = 4;
		subject.SubLevel = "h";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
