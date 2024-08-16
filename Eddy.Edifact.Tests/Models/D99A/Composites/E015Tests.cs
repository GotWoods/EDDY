using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E015Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:U:W:Z:W:Z:A:J:q";

		var expected = new E015_ProductDataInformation()
		{
			ItemDescriptionIdentification = "9",
			ItemDescription = "U",
			Quantity = "W",
			MonetaryAmount = "Z",
			ChargePeriodTypeCoded = "W",
			ChargeUnitCoded = "Z",
			CurrencyCoded = "A",
			InformationTypeIdentification = "J",
			FreeText = "q",
		};

		var actual = Map.MapComposite<E015_ProductDataInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
