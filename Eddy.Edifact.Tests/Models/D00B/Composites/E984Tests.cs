using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "N:6:T:O:P:H:c:t:N:w:4:W";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCode = "N",
			MonetaryAmount = "6",
			ItemDescription = "T",
			Quantity = "O",
			ChargePeriodTypeCode = "P",
			CurrencyIdentificationCode = "H",
			LocationNameCode = "c",
			FreeTextValue = "t",
			MaintenanceOperationCode = "N",
			RequirementDesignatorCode = "w",
			AgeValue = "4",
			Percentage = "W",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
