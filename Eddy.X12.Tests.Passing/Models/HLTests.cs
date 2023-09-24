using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HL*o*i*X*G";

		var expected = new HL_HierarchicalLevel()
		{
			HierarchicalIDNumber = "o",
			HierarchicalParentIDNumber = "i",
			HierarchicalLevelCode = "X",
			HierarchicalChildCode = "G",
		};

		var actual = Map.MapObject<HL_HierarchicalLevel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredHierarchicalIDNumber(string hierarchicalIDNumber, bool isValidExpected)
	{
		var subject = new HL_HierarchicalLevel();
		subject.HierarchicalLevelCode = "X";
		subject.HierarchicalIDNumber = hierarchicalIDNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredHierarchicalLevelCode(string hierarchicalLevelCode, bool isValidExpected)
	{
		var subject = new HL_HierarchicalLevel();
		subject.HierarchicalIDNumber = "o";
		subject.HierarchicalLevelCode = hierarchicalLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
