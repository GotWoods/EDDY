using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D10A;
using Eddy.Edifact.Models.D10A.Composites;

namespace Eddy.Edifact.Tests.Models.D10A;

public class APPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "APP+h++";

		var expected = new APP_Applicability()
		{
			ApplicabilityCodeQualifier = "h",
			ApplicabilityType = null,
			PartyIdentificationDetails = null,
		};

		var actual = Map.MapObject<APP_Applicability>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
