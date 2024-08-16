using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class CURTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CUR+++C+O";

		var expected = new CUR_Currencies()
		{
			CurrencyDetails = null,
			CurrencyDetails2 = null,
			RateOfExchange = "C",
			CurrencyMarketExchangeCoded = "O",
		};

		var actual = Map.MapObject<CUR_Currencies>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
