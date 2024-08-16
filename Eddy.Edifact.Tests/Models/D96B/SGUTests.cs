using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class SGUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SGU+G+W+Z+T+p+3+P";

		var expected = new SGU_SegmentUsageDetails()
		{
			SegmentTag = "G",
			RequirementDesignatorCoded = "W",
			MaximumNumberOfOccurrences = "Z",
			LevelNumber = "T",
			SequenceNumber = "p",
			MessageSectionCoded = "3",
			MaintenanceOperationCoded = "P",
		};

		var actual = Map.MapObject<SGU_SegmentUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredSegmentTag(string segmentTag, bool isValidExpected)
	{
		var subject = new SGU_SegmentUsageDetails();
		//Required fields
		//Test Parameters
		subject.SegmentTag = segmentTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
