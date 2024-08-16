using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPS+7+t+q";

		var expected = new CPS_ConsignmentPackingSequence()
		{
			HierarchicalStructureLevelIdentifier = "7",
			HierarchicalStructureParentIdentifier = "t",
			PackagingLevelCode = "q",
		};

		var actual = Map.MapObject<CPS_ConsignmentPackingSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredHierarchicalStructureLevelIdentifier(string hierarchicalStructureLevelIdentifier, bool isValidExpected)
	{
		var subject = new CPS_ConsignmentPackingSequence();
		//Required fields
		//Test Parameters
		subject.HierarchicalStructureLevelIdentifier = hierarchicalStructureLevelIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
