using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class GRUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GRU+L+5+4+4+Q";

		var expected = new GRU_SegmentGroupUsageDetails()
		{
			GroupIdentification = "L",
			RequirementDesignatorCoded = "5",
			MaximumNumberOfOccurrences = "4",
			MaintenanceOperationCoded = "4",
			SequenceNumber = "Q",
		};

		var actual = Map.MapObject<GRU_SegmentGroupUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredGroupIdentification(string groupIdentification, bool isValidExpected)
	{
		var subject = new GRU_SegmentGroupUsageDetails();
		//Required fields
		//Test Parameters
		subject.GroupIdentification = groupIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
