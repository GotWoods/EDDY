using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C223Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "nnL:p";

		var expected = new C223_DangerousGoodsShipmentFlashpoint()
		{
			ShipmentFlashpoint = "nnL",
			MeasurementUnitCode = "p",
		};

		var actual = Map.MapComposite<C223_DangerousGoodsShipmentFlashpoint>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
