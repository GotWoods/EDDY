using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class CPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPS+9+q+K";

		var expected = new CPS_ConsignmentPackingSequence()
		{
			HierarchicalIdNumber = "9",
			HierarchicalParentId = "q",
			PackagingLevelCoded = "K",
		};

		var actual = Map.MapObject<CPS_ConsignmentPackingSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredHierarchicalIdNumber(string hierarchicalIdNumber, bool isValidExpected)
	{
		var subject = new CPS_ConsignmentPackingSequence();
		//Required fields
		//Test Parameters
		subject.HierarchicalIdNumber = hierarchicalIdNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
