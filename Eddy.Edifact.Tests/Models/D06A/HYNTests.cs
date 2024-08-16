using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class HYNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HYN+3+p+Q++K";

		var expected = new HYN_HierarchyInformation()
		{
			HierarchyObjectCodeQualifier = "3",
			HierarchicalStructureRelationshipCode = "p",
			ActionCode = "Q",
			ItemNumberIdentification = null,
			HierarchicalStructureParentIdentifier = "K",
		};

		var actual = Map.MapObject<HYN_HierarchyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredHierarchyObjectCodeQualifier(string hierarchyObjectCodeQualifier, bool isValidExpected)
	{
		var subject = new HYN_HierarchyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchyObjectCodeQualifier = hierarchyObjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
