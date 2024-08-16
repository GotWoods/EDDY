using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class HYNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HYN+6+B+P++h";

		var expected = new HYN_HierarchyInformation()
		{
			HierarchyObjectQualifier = "6",
			HierarchicalLevelCoded = "B",
			ActionRequestNotificationCoded = "P",
			ItemNumberIdentification = null,
			HierarchicalParentId = "h",
		};

		var actual = Map.MapObject<HYN_HierarchyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredHierarchyObjectQualifier(string hierarchyObjectQualifier, bool isValidExpected)
	{
		var subject = new HYN_HierarchyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchyObjectQualifier = hierarchyObjectQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
