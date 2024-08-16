using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SGUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SGU+V+8+m+S+Z+b+L";

		var expected = new SGU_SegmentUsageDetails()
		{
			SegmentTag = "V",
			RequirementDesignatorCoded = "8",
			MaximumNumberOfOccurrences = "m",
			LevelNumber = "S",
			SequenceNumber = "Z",
			MessageSectionCoded = "b",
			MaintenanceOperationCoded = "L",
		};

		var actual = Map.MapObject<SGU_SegmentUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredSegmentTag(string segmentTag, bool isValidExpected)
	{
		var subject = new SGU_SegmentUsageDetails();
		//Required fields
		//Test Parameters
		subject.SegmentTag = segmentTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
