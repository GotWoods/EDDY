using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*1E*h13*7*3*le*hvA*1";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "1E",
			PriceQualifier = "h13",
			UnitPrice = 7,
			Quantity = 3,
			UnitOfMeasurementCode = "le",
			PriceMultiplierQualifier = "hvA",
			Multiplier = 1,
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
