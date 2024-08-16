using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class CLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CLI+u+";

		var expected = new CLI_ClinicalIntervention()
		{
			ClinicalInterventionQualifier = "u",
			ClinicalInterventionDetails = null,
		};

		var actual = Map.MapObject<CLI_ClinicalIntervention>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredClinicalInterventionQualifier(string clinicalInterventionQualifier, bool isValidExpected)
	{
		var subject = new CLI_ClinicalIntervention();
		//Required fields
		//Test Parameters
		subject.ClinicalInterventionQualifier = clinicalInterventionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
