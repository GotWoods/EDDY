using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D13A;
using Eddy.Edifact.Models.D13A.Composites;

namespace Eddy.Edifact.Tests.Models.D13A;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+P++++C+P+H+2+++x+e+V+";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCode = "P",
			HazardCode = null,
			UNDGInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackagingDangerLevelCode = "C",
			EmergencyProcedureForShipsIdentifier = "P",
			HazardMedicalFirstAidGuideIdentifier = "H",
			TransportEmergencyCardIdentifier = "2",
			HazardIdentificationPlacardDetails = null,
			DangerousGoodsLabel = null,
			PackingInstructionTypeCode = "x",
			TransportMeansDescriptionCode = "e",
			HazardousCargoTransportAuthorisationCode = "V",
			TunnelRestriction = null,
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
