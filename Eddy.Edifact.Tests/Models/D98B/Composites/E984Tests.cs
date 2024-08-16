using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:g:O:a:d:q:t:v:2:3";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCoded = "f",
			MonetaryAmount = "g",
			ItemDescription = "O",
			Quantity = "a",
			ChargePeriodTypeCoded = "d",
			CurrencyCoded = "q",
			PlaceLocationIdentification = "t",
			FreeText = "v",
			MaintenanceOperationCoded = "2",
			RequirementDesignatorCoded = "3",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
