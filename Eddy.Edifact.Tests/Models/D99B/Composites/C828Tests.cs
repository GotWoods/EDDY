using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C828Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:T:r:a";

		var expected = new C828_ClinicalInterventionDetails()
		{
			ClinicalInterventionIdentification = "W",
			CodeListIdentificationCode = "T",
			CodeListResponsibleAgencyCode = "r",
			ClinicalIntervention = "a",
		};

		var actual = Map.MapComposite<C828_ClinicalInterventionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
