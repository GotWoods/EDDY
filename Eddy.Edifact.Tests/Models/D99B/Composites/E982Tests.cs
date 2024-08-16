using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E982Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:P:2:y:l:K:e:5:0:J:k";

		var expected = new E982_TariffInformation()
		{
			RateTypeIdentification = "e",
			MonetaryAmountValue = "P",
			CurrencyIdentificationCode = "2",
			RatePlanCoded = "y",
			MonetaryAmountTypeCodeQualifier = "l",
			PeriodCountQuantity = "K",
			PriceChangeIndicatorCoded = "e",
			TotalMonetaryAmount = "5",
			DateValue = "0",
			DateValue2 = "J",
			SpecialConditionCode = "k",
		};

		var actual = Map.MapComposite<E982_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
