using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CUR+++H+M";

		var expected = new CUR_Currencies()
		{
			CurrencyDetails = null,
			CurrencyDetails2 = null,
			RateOfExchange = "H",
			ExchangeRateCurrencyMarketIdentifier = "M",
		};

		var actual = Map.MapObject<CUR_Currencies>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
