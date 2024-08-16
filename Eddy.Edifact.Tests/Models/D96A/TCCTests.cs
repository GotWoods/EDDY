using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TCC++++";

		var expected = new TCC_TransportChargeRateCalculations()
		{
			Charge = null,
			RateTariffClass = null,
			CommodityRateDetail = null,
			RateTariffClassDetail = null,
		};

		var actual = Map.MapObject<TCC_TransportChargeRateCalculations>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
