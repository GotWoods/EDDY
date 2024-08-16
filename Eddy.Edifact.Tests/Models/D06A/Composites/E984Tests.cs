using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E984Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "G:7:J:R:0:I:k:F:9:n:E:F";

		var expected = new E984_AssociatedChargesInformation()
		{
			ChargeUnitCode = "G",
			MonetaryAmount = "7",
			ItemDescription = "J",
			Quantity = "R",
			ChargePeriodTypeCode = "0",
			CurrencyIdentificationCode = "I",
			LocationIdentifier = "k",
			FreeText = "F",
			MaintenanceOperationCode = "9",
			RequirementDesignatorCode = "n",
			Age = "E",
			Percentage = "F",
		};

		var actual = Map.MapComposite<E984_AssociatedChargesInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
