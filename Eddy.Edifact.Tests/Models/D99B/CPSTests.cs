using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class CPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPS+u+L+8";

		var expected = new CPS_ConsignmentPackingSequence()
		{
			HierarchicalStructureLevelIdentifier = "u",
			HierarchicalStructureParentIdentifier = "L",
			PackagingLevelCoded = "8",
		};

		var actual = Map.MapObject<CPS_ConsignmentPackingSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredHierarchicalStructureLevelIdentifier(string hierarchicalStructureLevelIdentifier, bool isValidExpected)
	{
		var subject = new CPS_ConsignmentPackingSequence();
		//Required fields
		//Test Parameters
		subject.HierarchicalStructureLevelIdentifier = hierarchicalStructureLevelIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
