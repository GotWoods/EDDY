using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CUXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CUX+++9+s";

		var expected = new CUX_Currencies()
		{
			CurrencyDetails = null,
			CurrencyDetails2 = null,
			CurrencyExchangeRate = "9",
			ExchangeRateCurrencyMarketIdentifier = "s",
		};

		var actual = Map.MapObject<CUX_Currencies>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
