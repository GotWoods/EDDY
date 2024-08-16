using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+D++++X+o+w+0+++t+x+W";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCode = "D",
			HazardCode = null,
			UNDGInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackagingDangerLevelCode = "X",
			EmergencyProcedureForShipsIdentifier = "o",
			HazardMedicalFirstAidGuideIdentifier = "w",
			TransportEmergencyCardIdentifier = "0",
			HazardIdentificationPlacardDetails = null,
			DangerousGoodsLabel = null,
			PackingInstructionTypeCode = "t",
			TransportMeansDescriptionCode = "x",
			HazardousCargoTransportAuthorisationCode = "W",
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
