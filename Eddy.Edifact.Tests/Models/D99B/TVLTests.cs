using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class TVLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TVL++++++J+A";

		var expected = new TVL_TravelProductInformation()
		{
			ProductDateAndTime = null,
			Location = null,
			CompanyIdentification = null,
			ProductIdentificationDetails = null,
			SequenceNumberDetails = null,
			LineItemNumber = "J",
			ProcessingIndicatorDescriptionCode = "A",
		};

		var actual = Map.MapObject<TVL_TravelProductInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
