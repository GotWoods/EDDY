using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C836Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "C:r:1:D";

		var expected = new C836_ClinicalInformationDetails()
		{
			ClinicalInformationDescriptionIdentifier = "C",
			CodeListIdentificationCode = "r",
			CodeListResponsibleAgencyCode = "1",
			ClinicalInformationDescription = "D",
		};

		var actual = Map.MapComposite<C836_ClinicalInformationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
