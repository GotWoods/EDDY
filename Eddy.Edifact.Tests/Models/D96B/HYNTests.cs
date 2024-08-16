using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class HYNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HYN+L+u+W+";

		var expected = new HYN_HierarchyInformation()
		{
			HierarchyObjectQualifier = "L",
			HierarchicalLevelCoded = "u",
			ActionRequestNotificationCoded = "W",
			ItemNumberIdentification = null,
		};

		var actual = Map.MapObject<HYN_HierarchyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredHierarchyObjectQualifier(string hierarchyObjectQualifier, bool isValidExpected)
	{
		var subject = new HYN_HierarchyInformation();
		//Required fields
		subject.HierarchicalLevelCoded = "u";
		//Test Parameters
		subject.HierarchyObjectQualifier = hierarchyObjectQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredHierarchicalLevelCoded(string hierarchicalLevelCoded, bool isValidExpected)
	{
		var subject = new HYN_HierarchyInformation();
		//Required fields
		subject.HierarchyObjectQualifier = "L";
		//Test Parameters
		subject.HierarchicalLevelCoded = hierarchicalLevelCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
