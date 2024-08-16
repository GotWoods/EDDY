using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E015Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "p:k:T:S:U:H:P:Y:v";

		var expected = new E015_ProductDataInformation()
		{
			ItemDescriptionCode = "p",
			ItemDescription = "k",
			Quantity = "T",
			MonetaryAmount = "S",
			ChargePeriodTypeCode = "U",
			ChargeUnitCode = "H",
			CurrencyIdentificationCode = "P",
			InformationTypeCode = "Y",
			FreeText = "v",
		};

		var actual = Map.MapComposite<E015_ProductDataInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
