using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class ELUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELU+T+s+C+U+j+y+G+u";

		var expected = new ELU_DataElementUsageDetails()
		{
			DataElementTag = "T",
			RequirementDesignatorCoded = "s",
			SequenceNumber = "C",
			MaintenanceOperationCoded = "U",
			MaximumNumberOfOccurrences = "j",
			CodeValueSourceCoded = "y",
			ValidationCriteriaCoded = "G",
			DataElementUsageTypeCoded = "u",
		};

		var actual = Map.MapObject<ELU_DataElementUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredDataElementTag(string dataElementTag, bool isValidExpected)
	{
		var subject = new ELU_DataElementUsageDetails();
		//Required fields
		//Test Parameters
		subject.DataElementTag = dataElementTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
