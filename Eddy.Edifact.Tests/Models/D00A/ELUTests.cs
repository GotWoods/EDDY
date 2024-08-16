using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ELUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELU+9+9+R+e+y+I+E+n";

		var expected = new ELU_DataElementUsageDetails()
		{
			DataElementTagIdentifier = "9",
			RequirementDesignatorCode = "9",
			SequencePositionIdentifier = "R",
			MaintenanceOperationCode = "e",
			OccurrencesMaximumNumber = "y",
			CodeValueSourceCode = "I",
			ValidationCriteriaCode = "E",
			DataElementUsageTypeCode = "n",
		};

		var actual = Map.MapObject<ELU_DataElementUsageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredDataElementTagIdentifier(string dataElementTagIdentifier, bool isValidExpected)
	{
		var subject = new ELU_DataElementUsageDetails();
		//Required fields
		//Test Parameters
		subject.DataElementTagIdentifier = dataElementTagIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
