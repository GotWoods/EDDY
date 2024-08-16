using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class GRUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GRU+T+n+W+6+S";

		var expected = new GRU_SegmentGroupUsageDetails()
		{
			GroupIdentifier = "T",
			RequirementDesignatorCode = "n",
			OccurrencesMaximumNumber = "W",
			MaintenanceOperationCode = "6",
			SequencePositionIdentifier = "S",
		};

		var actual = Map.MapObject<GRU_SegmentGroupUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredGroupIdentifier(string groupIdentifier, bool isValidExpected)
	{
		var subject = new GRU_SegmentGroupUsageDetails();
		//Required fields
		//Test Parameters
		subject.GroupIdentifier = groupIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
