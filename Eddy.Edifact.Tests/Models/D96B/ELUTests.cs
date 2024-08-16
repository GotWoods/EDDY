using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class ELUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELU+d+h+w+v";

		var expected = new ELU_DataElementUsageDetails()
		{
			DataElementTag = "d",
			RequirementDesignatorCoded = "h",
			SequenceNumber = "w",
			MaintenanceOperationCoded = "v",
		};

		var actual = Map.MapObject<ELU_DataElementUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredDataElementTag(string dataElementTag, bool isValidExpected)
	{
		var subject = new ELU_DataElementUsageDetails();
		//Required fields
		//Test Parameters
		subject.DataElementTag = dataElementTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
