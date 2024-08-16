using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class GRUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GRU+4+b+v+J+l";

		var expected = new GRU_SegmentGroupUsageDetails()
		{
			GroupIdentification = "4",
			RequirementDesignatorCoded = "b",
			MaximumNumberOfOccurrences = "v",
			MaintenanceOperationCoded = "J",
			SequenceNumber = "l",
		};

		var actual = Map.MapObject<GRU_SegmentGroupUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredGroupIdentification(string groupIdentification, bool isValidExpected)
	{
		var subject = new GRU_SegmentGroupUsageDetails();
		//Required fields
		//Test Parameters
		subject.GroupIdentification = groupIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
