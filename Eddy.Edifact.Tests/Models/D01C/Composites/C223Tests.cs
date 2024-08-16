using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C223Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g0K:2";

		var expected = new C223_DangerousGoodsShipmentFlashpoint()
		{
			ShipmentFlashpointDegree = "g0K",
			MeasurementUnitCode = "2",
		};

		var actual = Map.MapComposite<C223_DangerousGoodsShipmentFlashpoint>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
