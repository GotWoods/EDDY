using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CUR+++q+e";

		var expected = new CUR_Currencies()
		{
			CurrencyDetails = null,
			CurrencyDetails2 = null,
			CurrencyExchangeRate = "q",
			ExchangeRateCurrencyMarketIdentifier = "e",
		};

		var actual = Map.MapObject<CUR_Currencies>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
