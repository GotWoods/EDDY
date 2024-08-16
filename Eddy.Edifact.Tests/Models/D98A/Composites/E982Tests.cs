using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E982Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "B:N:0:u:8:m:g:I:R:h:V";

		var expected = new E982_TariffInformation()
		{
			RateTypeIdentification = "B",
			MonetaryAmount = "N",
			CurrencyCoded = "0",
			RatePlanCoded = "u",
			MonetaryAmountTypeQualifier = "8",
			NumberOfPeriods = "m",
			PriceChangeIndicatorCoded = "g",
			TotalMonetaryAmount = "I",
			Date = "R",
			Date2 = "h",
			SpecialConditionsCoded = "V",
		};

		var actual = Map.MapComposite<E982_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
