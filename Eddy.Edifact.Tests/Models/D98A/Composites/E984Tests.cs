using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "L:d:l:b:y:M:u:V:q";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCoded = "L",
			MonetaryAmount = "d",
			ItemDescription = "l",
			Quantity = "b",
			ChargePeriodTypeCoded = "y",
			CurrencyCoded = "M",
			PlaceLocationIdentification = "u",
			FreeText = "V",
			MaintenanceOperationCoded = "q",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
