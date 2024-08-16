using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:u:E:B:e:O:7:a:n:z";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCoded = "h",
			MonetaryAmountValue = "u",
			ItemDescription = "E",
			Quantity = "B",
			ChargePeriodTypeCoded = "e",
			CurrencyIdentificationCode = "O",
			LocationNameCode = "7",
			FreeTextValue = "a",
			MaintenanceOperationCoded = "n",
			RequirementDesignatorCoded = "z",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
