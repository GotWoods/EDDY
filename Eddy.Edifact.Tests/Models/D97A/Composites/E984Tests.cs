using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:j:g:f:a:8:7:3";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCoded = "h",
			MonetaryAmount = "j",
			ItemDescription = "g",
			Quantity = "f",
			ChargePeriodTypeCoded = "a",
			CurrencyCoded = "8",
			PlaceLocationIdentification = "7",
			FreeText = "3",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
