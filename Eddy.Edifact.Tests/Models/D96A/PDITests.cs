using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PDI+K++";

		var expected = new PDI_PersonDemographicInformation()
		{
			SexCoded = "K",
			MaritalStatusDetails = null,
			ReligionDetails = null,
		};

		var actual = Map.MapObject<PDI_PersonDemographicInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
