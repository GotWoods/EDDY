using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+H++++d+d+K+T+++h+V+I";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCode = "H",
			HazardCode = null,
			UNDGInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackagingDangerLevelCode = "d",
			EmergencyProcedureForShipsIdentifier = "d",
			HazardMedicalFirstAidGuideIdentifier = "K",
			TransportEmergencyCardIdentifier = "T",
			HazardIdentificationPlacardDetails = null,
			DangerousGoodsLabel = null,
			PackingInstructionTypeCode = "h",
			HazardousMeansOfTransportCategoryCode = "V",
			HazardousCargoTransportAuthorisationCode = "I",
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
