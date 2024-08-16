using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+l++++E+e+e+W+++9+0+Y";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCoded = "l",
			HazardCode = null,
			UNDGInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackingGroupCoded = "E",
			EMSNumber = "e",
			MFAG = "e",
			TremCardNumber = "W",
			HazardIdentificationPlacardDetails = null,
			DangerousGoodsLabel = null,
			PackingInstructionCoded = "9",
			CategoryOfMeansOfTransportCoded = "0",
			PermissionForTransportCoded = "Y",
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
