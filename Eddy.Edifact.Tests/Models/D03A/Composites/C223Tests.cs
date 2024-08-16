using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C223Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "MQo:I";

		var expected = new C223_DangerousGoodsShipmentFlashpoint()
		{
			ShipmentFlashpointDegree = "MQo",
			MeasurementUnitCode = "I",
		};

		var actual = Map.MapComposite<C223_DangerousGoodsShipmentFlashpoint>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
