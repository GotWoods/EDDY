using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C836Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:H:z:E";

		var expected = new C836_ClinicalInformationDetails()
		{
			ClinicalInformationIdentification = "A",
			CodeListIdentificationCode = "H",
			CodeListResponsibleAgencyCode = "z",
			ClinicalInformation = "E",
		};

		var actual = Map.MapComposite<C836_ClinicalInformationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
