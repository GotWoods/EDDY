using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E982Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:a:j:f:M:Y:X:5:8:4:X:a";

		var expected = new E982_TariffInformation()
		{
			RateTypeIdentifier = "9",
			MonetaryAmount = "a",
			CurrencyIdentificationCode = "j",
			RatePlanCode = "f",
			MonetaryAmountTypeCodeQualifier = "M",
			PeriodCountQuantity = "Y",
			PriceChangeTypeCode = "X",
			TotalMonetaryAmount = "5",
			DateValue = "8",
			DateValue2 = "4",
			SpecialConditionCode = "X",
			Quantity = "a",
		};

		var actual = Map.MapComposite<E982_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
