using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PDI+j++";

		var expected = new PDI_PersonDemographicInformation()
		{
			GenderCode = "j",
			MaritalStatusDetails = null,
			ReligionDetails = null,
		};

		var actual = Map.MapObject<PDI_PersonDemographicInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
