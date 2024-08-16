using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A;

public class ELUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELU+P+l+1+0+E";

		var expected = new ELU_DataElementUsageDetails()
		{
			DataElementTag = "P",
			RequirementDesignatorCoded = "l",
			SequenceNumber = "1",
			MaintenanceOperationCoded = "0",
			MaximumNumberOfOccurrences = "E",
		};

		var actual = Map.MapObject<ELU_DataElementUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredDataElementTag(string dataElementTag, bool isValidExpected)
	{
		var subject = new ELU_DataElementUsageDetails();
		//Required fields
		//Test Parameters
		subject.DataElementTag = dataElementTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
