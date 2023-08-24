using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*HA*Na4*4*6*g8*cYm*6";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "HA",
			PriceQualifier = "Na4",
			UnitPrice = 4,
			Quantity = 6,
			UnitOfMeasurementCode = "g8",
			PriceMultiplierQualifier = "cYm",
			Multiplier = 6,
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
