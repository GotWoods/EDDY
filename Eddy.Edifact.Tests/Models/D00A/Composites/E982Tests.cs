using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E982Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:u:8:4:V:X:c:S:2:O:e";

		var expected = new E982_TariffInformation()
		{
			RateTypeIdentifier = "w",
			MonetaryAmount = "u",
			CurrencyIdentificationCode = "8",
			RatePlanCode = "4",
			MonetaryAmountTypeCodeQualifier = "V",
			PeriodCountQuantity = "X",
			PriceChangeTypeCode = "c",
			TotalMonetaryAmount = "S",
			DateValue = "2",
			DateValue2 = "O",
			SpecialConditionCode = "e",
		};

		var actual = Map.MapComposite<E982_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
