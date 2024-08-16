using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class APRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "APR+S++";

		var expected = new APR_AdditionalPriceInformation()
		{
			TradeClassCode = "S",
			PriceMultiplierInformation = null,
			ReasonForChange = null,
		};

		var actual = Map.MapObject<APR_AdditionalPriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
