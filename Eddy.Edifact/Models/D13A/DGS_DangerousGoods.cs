using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13A.Composites;

namespace Eddy.Edifact.Models.D13A;

[Segment("DGS")]
public class DGS_DangerousGoods : EdifactSegment
{
	[Position(1)]
	public string DangerousGoodsRegulationsCode { get; set; }

	[Position(2)]
	public C205_HazardCode HazardCode { get; set; }

	[Position(3)]
	public C234_UNDGInformation UNDGInformation { get; set; }

	[Position(4)]
	public C223_DangerousGoodsShipmentFlashpoint DangerousGoodsShipmentFlashpoint { get; set; }

	[Position(5)]
	public string PackagingDangerLevelCode { get; set; }

	[Position(6)]
	public string EmergencyProcedureForShipsIdentifier { get; set; }

	[Position(7)]
	public string HazardMedicalFirstAidGuideIdentifier { get; set; }

	[Position(8)]
	public string TransportEmergencyCardIdentifier { get; set; }

	[Position(9)]
	public C235_HazardIdentificationPlacardDetails HazardIdentificationPlacardDetails { get; set; }

	[Position(10)]
	public C236_DangerousGoodsLabel DangerousGoodsLabel { get; set; }

	[Position(11)]
	public string PackingInstructionTypeCode { get; set; }

	[Position(12)]
	public string TransportMeansDescriptionCode { get; set; }

	[Position(13)]
	public string HazardousCargoTransportAuthorisationCode { get; set; }

	[Position(14)]
	public C289_TunnelRestriction TunnelRestriction { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DGS_DangerousGoods>(this);
		validator.Length(x => x.DangerousGoodsRegulationsCode, 1, 3);
		validator.Length(x => x.PackagingDangerLevelCode, 1, 3);
		validator.Length(x => x.EmergencyProcedureForShipsIdentifier, 1, 8);
		validator.Length(x => x.HazardMedicalFirstAidGuideIdentifier, 1, 4);
		validator.Length(x => x.TransportEmergencyCardIdentifier, 1, 10);
		validator.Length(x => x.PackingInstructionTypeCode, 1, 3);
		validator.Length(x => x.TransportMeansDescriptionCode, 1, 8);
		validator.Length(x => x.HazardousCargoTransportAuthorisationCode, 1, 3);
		return validator.Results;
	}
}
