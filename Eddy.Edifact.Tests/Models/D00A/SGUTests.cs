using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SGUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SGU+g+S+s+Q+S+S+G";

		var expected = new SGU_SegmentUsageDetails()
		{
			SegmentTagIdentifier = "g",
			RequirementDesignatorCode = "S",
			OccurrencesMaximumNumber = "s",
			LevelNumber = "Q",
			SequencePositionIdentifier = "S",
			MessageSectionCode = "S",
			MaintenanceOperationCode = "G",
		};

		var actual = Map.MapObject<SGU_SegmentUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredSegmentTagIdentifier(string segmentTagIdentifier, bool isValidExpected)
	{
		var subject = new SGU_SegmentUsageDetails();
		//Required fields
		//Test Parameters
		subject.SegmentTagIdentifier = segmentTagIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
