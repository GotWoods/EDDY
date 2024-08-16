using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C836Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:4:u:8";

		var expected = new C836_ClinicalInformationDetails()
		{
			ClinicalInformationDescriptionIdentifier = "H",
			CodeListIdentificationCode = "4",
			CodeListResponsibleAgencyCode = "u",
			ClinicalInformationDescription = "8",
		};

		var actual = Map.MapComposite<C836_ClinicalInformationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
