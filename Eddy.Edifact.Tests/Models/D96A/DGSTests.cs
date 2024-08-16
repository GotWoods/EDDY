using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+O++++5+v+X+O+++7+t+E";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCoded = "O",
			HazardCode = null,
			UndgInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackingGroupCoded = "5",
			EMSNumber = "v",
			MFAG = "X",
			TremCardNumber = "O",
			HazardIdentification = null,
			DangerousGoodsLabel = null,
			PackingInstructionCoded = "7",
			CategoryOfMeansOfTransportCoded = "t",
			PermissionForTransportCoded = "E",
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
