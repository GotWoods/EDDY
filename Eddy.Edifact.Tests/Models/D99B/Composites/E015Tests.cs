using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E015Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:6:Z:X:C:B:u:h:I";

		var expected = new E015_ProductDataInformation()
		{
			ItemDescriptionIdentification = "i",
			ItemDescription = "6",
			Quantity = "Z",
			MonetaryAmountValue = "X",
			ChargePeriodTypeCoded = "C",
			ChargeUnitCoded = "B",
			CurrencyIdentificationCode = "u",
			InformationTypeIdentification = "h",
			FreeTextValue = "I",
		};

		var actual = Map.MapComposite<E015_ProductDataInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
