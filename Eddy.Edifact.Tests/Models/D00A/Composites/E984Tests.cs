using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "y:x:7:n:Y:x:G:U:F:d";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCode = "y",
			MonetaryAmount = "x",
			ItemDescription = "7",
			Quantity = "n",
			ChargePeriodTypeCode = "Y",
			CurrencyIdentificationCode = "x",
			LocationNameCode = "G",
			FreeTextValue = "U",
			MaintenanceOperationCode = "F",
			RequirementDesignatorCode = "d",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
