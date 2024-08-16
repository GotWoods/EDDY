using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:V:H:9:y:q:c:4:d:z:W:K";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCode = "X",
			MonetaryAmount = "V",
			ItemDescription = "H",
			Quantity = "9",
			ChargePeriodTypeCode = "y",
			CurrencyIdentificationCode = "q",
			LocationNameCode = "c",
			FreeText = "4",
			MaintenanceOperationCode = "d",
			RequirementDesignatorCode = "z",
			Age = "W",
			Percentage = "K",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
