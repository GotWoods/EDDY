using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class HYNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HYN+n+a+I++q";

		var expected = new HYN_HierarchyInformation()
		{
			HierarchyObjectCodeQualifier = "n",
			HierarchicalStructureRelationshipCode = "a",
			ActionRequestNotificationDescriptionCode = "I",
			ItemNumberIdentification = null,
			HierarchicalStructureParentIdentifier = "q",
		};

		var actual = Map.MapObject<HYN_HierarchyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredHierarchyObjectCodeQualifier(string hierarchyObjectCodeQualifier, bool isValidExpected)
	{
		var subject = new HYN_HierarchyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchyObjectCodeQualifier = hierarchyObjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
