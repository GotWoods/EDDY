using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ELUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELU+i+W+p+8";

		var expected = new ELU_DataElementUsageDetails()
		{
			DataElementTag = "i",
			RequirementDesignatorCoded = "W",
			SequenceNumber = "p",
			MaintenanceOperationCoded = "8",
		};

		var actual = Map.MapObject<ELU_DataElementUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredDataElementTag(string dataElementTag, bool isValidExpected)
	{
		var subject = new ELU_DataElementUsageDetails();
		//Required fields
		//Test Parameters
		subject.DataElementTag = dataElementTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
