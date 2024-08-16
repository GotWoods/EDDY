using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C828Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "K:z:r:9";

		var expected = new C828_ClinicalInterventionDetails()
		{
			ClinicalInterventionDescriptionCode = "K",
			CodeListIdentificationCode = "z",
			CodeListResponsibleAgencyCode = "r",
			ClinicalInterventionDescription = "9",
		};

		var actual = Map.MapComposite<C828_ClinicalInterventionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
