using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class CUXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CUX+++K+c";

		var expected = new CUX_Currencies()
		{
			CurrencyDetails = null,
			CurrencyDetails2 = null,
			RateOfExchange = "K",
			ExchangeRateCurrencyMarketIdentifier = "c",
		};

		var actual = Map.MapObject<CUX_Currencies>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
