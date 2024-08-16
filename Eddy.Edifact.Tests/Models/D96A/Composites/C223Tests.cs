using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C223Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Ls4:K";

		var expected = new C223_DangerousGoodsShipmentFlashpoint()
		{
			ShipmentFlashpoint = "Ls4",
			MeasureUnitQualifier = "K",
		};

		var actual = Map.MapComposite<C223_DangerousGoodsShipmentFlashpoint>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
