using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+T++++S+b+m+t+++c+X+M";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCoded = "T",
			HazardCode = null,
			UndgInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackingGroupCoded = "S",
			EMSNumber = "b",
			MFAG = "m",
			TremCardNumber = "t",
			HazardIdentificationPlacardDetails = null,
			DangerousGoodsLabel = null,
			PackingInstructionCoded = "c",
			CategoryOfMeansOfTransportCoded = "X",
			PermissionForTransportCoded = "M",
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
