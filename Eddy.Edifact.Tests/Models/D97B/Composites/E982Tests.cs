using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E982Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:o:s:R:H:B:M:u:3:M:J";

		var expected = new E982_TariffInformation()
		{
			RateTypeIdentification = "O",
			MonetaryAmount = "o",
			CurrencyCoded = "s",
			RatePlanCoded = "R",
			MonetaryAmountTypeQualifier = "H",
			NumberOfPeriods = "B",
			PriceChangeIndicatorCoded = "M",
			TotalMonetaryAmount = "u",
			Date = "3",
			Date2 = "M",
			SpecialConditionsCoded = "J",
		};

		var actual = Map.MapComposite<E982_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
