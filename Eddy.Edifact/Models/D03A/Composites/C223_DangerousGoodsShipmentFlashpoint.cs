using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("C223")]
public class C223_DangerousGoodsShipmentFlashpoint : EdifactComponent
{
	[Position(1)]
	public string ShipmentFlashpointDegree { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C223_DangerousGoodsShipmentFlashpoint>(this);
		validator.Length(x => x.ShipmentFlashpointDegree, 3);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		return validator.Results;
	}
}
