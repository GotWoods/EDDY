using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CUXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CUX+++L+g";

		var expected = new CUX_Currencies()
		{
			CurrencyDetails = null,
			CurrencyDetails2 = null,
			RateOfExchange = "L",
			CurrencyMarketExchangeCoded = "g",
		};

		var actual = Map.MapObject<CUX_Currencies>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
