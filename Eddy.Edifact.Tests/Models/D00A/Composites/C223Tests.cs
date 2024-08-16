using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C223Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "AyR:O";

		var expected = new C223_DangerousGoodsShipmentFlashpoint()
		{
			ShipmentFlashpointValue = "AyR",
			MeasurementUnitCode = "O",
		};

		var actual = Map.MapComposite<C223_DangerousGoodsShipmentFlashpoint>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
