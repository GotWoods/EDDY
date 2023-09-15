using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class HLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HL*v*u*n*t";

		var expected = new HL_HierarchicalLevel()
		{
			HierarchicalIDNumber = "v",
			HierarchicalParentIDNumber = "u",
			HierarchicalLevelCode = "n",
			HierarchicalChildCode = "t",
		};

		var actual = Map.MapObject<HL_HierarchicalLevel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredHierarchicalIDNumber(string hierarchicalIDNumber, bool isValidExpected)
	{
		var subject = new HL_HierarchicalLevel();
		subject.HierarchicalLevelCode = "n";
		subject.HierarchicalIDNumber = hierarchicalIDNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredHierarchicalLevelCode(string hierarchicalLevelCode, bool isValidExpected)
	{
		var subject = new HL_HierarchicalLevel();
		subject.HierarchicalIDNumber = "v";
		subject.HierarchicalLevelCode = hierarchicalLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
