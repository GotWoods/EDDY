using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class HYNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HYN+A+T+Z++E";

		var expected = new HYN_HierarchyInformation()
		{
			HierarchyObjectCodeQualifier = "A",
			HierarchicalLevelCoded = "T",
			ActionRequestNotificationDescriptionCode = "Z",
			ItemNumberIdentification = null,
			HierarchicalStructureParentIdentifier = "E",
		};

		var actual = Map.MapObject<HYN_HierarchyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredHierarchyObjectCodeQualifier(string hierarchyObjectCodeQualifier, bool isValidExpected)
	{
		var subject = new HYN_HierarchyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchyObjectCodeQualifier = hierarchyObjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
