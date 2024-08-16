using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:H:O:I:K:W:H:V:S";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCoded = "v",
			MonetaryAmount = "H",
			ItemDescription = "O",
			Quantity = "I",
			ChargePeriodTypeCoded = "K",
			CurrencyCoded = "W",
			PlaceLocationIdentification = "H",
			FreeText = "V",
			MaintenanceOperationCoded = "S",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
