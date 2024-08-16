using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TVLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TVL++++++n+1";

		var expected = new TVL_TravelProductInformation()
		{
			ProductDateAndTime = null,
			Location = null,
			CompanyIdentification = null,
			ProductIdentificationDetails = null,
			SequenceNumberDetails = null,
			LineItemIdentifier = "n",
			ProcessingIndicatorDescriptionCode = "1",
		};

		var actual = Map.MapObject<TVL_TravelProductInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
