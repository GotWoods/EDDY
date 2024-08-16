using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class TVLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TVL++++++8+K";

		var expected = new TVL_TravelProductInformation()
		{
			ProductDateAndTime = null,
			Location = null,
			CompanyIdentification = null,
			ProductIdentificationDetails = null,
			SequenceNumberDetails = null,
			LineItemNumber = "8",
			ProcessingIndicatorCoded = "K",
		};

		var actual = Map.MapObject<TVL_TravelProductInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
