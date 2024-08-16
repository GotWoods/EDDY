using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E982Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:i:x:y:b:R:k:x:Z:M:k:D:x";

		var expected = new E982_TariffInformation()
		{
			RateTypeIdentifier = "w",
			MonetaryAmount = "i",
			CurrencyIdentificationCode = "x",
			RatePlanCode = "y",
			MonetaryAmountTypeCodeQualifier = "b",
			PeriodCountQuantity = "R",
			PriceChangeTypeCode = "k",
			TotalMonetaryAmount = "x",
			Date = "Z",
			Date2 = "M",
			SpecialConditionCode = "k",
			Quantity = "D",
			StatusDescriptionCode = "x",
		};

		var actual = Map.MapComposite<E982_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
