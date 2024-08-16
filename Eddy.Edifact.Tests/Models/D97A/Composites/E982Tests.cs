using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E982Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:a:U:B:U:u:U:i:8:F";

		var expected = new E982_TariffInformation()
		{
			RateTypeIdentification = "X",
			MonetaryAmount = "a",
			CurrencyCoded = "U",
			RatePlanCoded = "B",
			MonetaryAmountTypeQualifier = "U",
			NumberOfPeriods = "u",
			PriceChangeIndicatorCoded = "U",
			TotalMonetaryAmount = "i",
			Date = "8",
			Date2 = "F",
		};

		var actual = Map.MapComposite<E982_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
