using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class SGUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SGU+2+n+H+G+h+P+C";

		var expected = new SGU_SegmentUsageDetails()
		{
			SegmentTag = "2",
			RequirementDesignatorCoded = "n",
			MaximumNumberOfOccurrences = "H",
			LevelNumber = "G",
			SequenceNumber = "h",
			MessageSectionCoded = "P",
			MaintenanceOperationCoded = "C",
		};

		var actual = Map.MapObject<SGU_SegmentUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredSegmentTag(string segmentTag, bool isValidExpected)
	{
		var subject = new SGU_SegmentUsageDetails();
		//Required fields
		//Test Parameters
		subject.SegmentTag = segmentTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
