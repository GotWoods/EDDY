using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("DGS")]
public class DGS_DangerousGoods : EdifactSegment
{
	[Position(1)]
	public string DangerousGoodsRegulationsCoded { get; set; }

	[Position(2)]
	public C205_HazardCode HazardCode { get; set; }

	[Position(3)]
	public C234_UndgInformation UndgInformation { get; set; }

	[Position(4)]
	public C223_DangerousGoodsShipmentFlashpoint DangerousGoodsShipmentFlashpoint { get; set; }

	[Position(5)]
	public string PackingGroupCoded { get; set; }

	[Position(6)]
	public string EMSNumber { get; set; }

	[Position(7)]
	public string MFAG { get; set; }

	[Position(8)]
	public string TremCardNumber { get; set; }

	[Position(9)]
	public C235_HazardIdentification HazardIdentificationPlacardDetails { get; set; }

	[Position(10)]
	public C236_DangerousGoodsLabel DangerousGoodsLabel { get; set; }

	[Position(11)]
	public string PackingInstructionCoded { get; set; }

	[Position(12)]
	public string CategoryOfMeansOfTransportCoded { get; set; }

	[Position(13)]
	public string PermissionForTransportCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DGS_DangerousGoods>(this);
		validator.Length(x => x.DangerousGoodsRegulationsCoded, 1, 3);
		validator.Length(x => x.PackingGroupCoded, 1, 3);
		validator.Length(x => x.EMSNumber, 1, 6);
		validator.Length(x => x.MFAG, 1, 4);
		validator.Length(x => x.TremCardNumber, 1, 10);
		validator.Length(x => x.PackingInstructionCoded, 1, 3);
		validator.Length(x => x.CategoryOfMeansOfTransportCoded, 1, 3);
		validator.Length(x => x.PermissionForTransportCoded, 1, 3);
		return validator.Results;
	}
}
