using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CLI+T+";

		var expected = new CLI_ClinicalIntervention()
		{
			ClinicalInterventionTypeCodeQualifier = "T",
			ClinicalInterventionDetails = null,
		};

		var actual = Map.MapObject<CLI_ClinicalIntervention>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredClinicalInterventionTypeCodeQualifier(string clinicalInterventionTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new CLI_ClinicalIntervention();
		//Required fields
		//Test Parameters
		subject.ClinicalInterventionTypeCodeQualifier = clinicalInterventionTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
