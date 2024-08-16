using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C828Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "u:l:F:u";

		var expected = new C828_ClinicalInterventionDetails()
		{
			ClinicalInterventionIdentification = "u",
			CodeListQualifier = "l",
			CodeListResponsibleAgencyCoded = "F",
			ClinicalIntervention = "u",
		};

		var actual = Map.MapComposite<C828_ClinicalInterventionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
