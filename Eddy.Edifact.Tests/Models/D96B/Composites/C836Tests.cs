using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C836Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "d:E:J:0";

		var expected = new C836_ClinicalInformationDetails()
		{
			ClinicalInformationIdentification = "d",
			CodeListQualifier = "E",
			CodeListResponsibleAgencyCoded = "J",
			ClinicalInformation = "0",
		};

		var actual = Map.MapComposite<C836_ClinicalInformationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
