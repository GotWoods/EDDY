using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C828Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "7:P:P:N";

		var expected = new C828_ClinicalInterventionDetails()
		{
			ClinicalInterventionDescriptionCode = "7",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "P",
			ClinicalInterventionDescription = "N",
		};

		var actual = Map.MapComposite<C828_ClinicalInterventionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
