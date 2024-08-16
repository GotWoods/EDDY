using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class APRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "APR+7++";

		var expected = new APR_AdditionalPriceInformation()
		{
			ClassOfTradeCoded = "7",
			PriceMultiplierInformation = null,
			ReasonForChange = null,
		};

		var actual = Map.MapObject<APR_AdditionalPriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
