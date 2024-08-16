using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E015Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:T:P:C:7:D:S:d:y";

		var expected = new E015_ProductDataInformation()
		{
			ItemDescriptionCode = "S",
			ItemDescription = "T",
			Quantity = "P",
			MonetaryAmount = "C",
			ChargePeriodTypeCode = "7",
			ChargeUnitCode = "D",
			CurrencyIdentificationCode = "S",
			InformationTypeCode = "d",
			FreeTextValue = "y",
		};

		var actual = Map.MapComposite<E015_ProductDataInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
