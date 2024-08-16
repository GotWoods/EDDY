using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C223")]
public class C223_DangerousGoodsShipmentFlashpoint : EdifactComponent
{
	[Position(1)]
	public string ShipmentFlashpoint { get; set; }

	[Position(2)]
	public string MeasureUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C223_DangerousGoodsShipmentFlashpoint>(this);
		validator.Length(x => x.ShipmentFlashpoint, 3);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		return validator.Results;
	}
}
