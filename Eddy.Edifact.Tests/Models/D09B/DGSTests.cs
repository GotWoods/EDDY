using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D09B;
using Eddy.Edifact.Models.D09B.Composites;

namespace Eddy.Edifact.Tests.Models.D09B;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+u++++h+o+8+q+++9+5+k+";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCode = "u",
			HazardCode = null,
			UNDGInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackagingDangerLevelCode = "h",
			EmergencyProcedureForShipsIdentifier = "o",
			HazardMedicalFirstAidGuideIdentifier = "8",
			TransportEmergencyCardIdentifier = "q",
			HazardIdentificationPlacardDetails = null,
			DangerousGoodsLabel = null,
			PackingInstructionTypeCode = "9",
			TransportMeansDescriptionCode = "5",
			HazardousCargoTransportAuthorisationCode = "k",
			TunnelRestriction = null,
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
