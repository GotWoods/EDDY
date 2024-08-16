using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPS+E+Q+N";

		var expected = new CPS_ConsignmentPackingSequence()
		{
			HierarchicalIdNumber = "E",
			HierarchicalParentId = "Q",
			PackagingLevelCoded = "N",
		};

		var actual = Map.MapObject<CPS_ConsignmentPackingSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredHierarchicalIdNumber(string hierarchicalIdNumber, bool isValidExpected)
	{
		var subject = new CPS_ConsignmentPackingSequence();
		//Required fields
		//Test Parameters
		subject.HierarchicalIdNumber = hierarchicalIdNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
