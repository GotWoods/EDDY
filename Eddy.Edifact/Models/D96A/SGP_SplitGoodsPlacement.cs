using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("SGP")]
public class SGP_SplitGoodsPlacement : EdifactSegment
{
	[Position(1)]
	public C237_EquipmentIdentification EquipmentIdentification { get; set; }

	[Position(2)]
	public string NumberOfPackages { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SGP_SplitGoodsPlacement>(this);
		validator.Required(x=>x.EquipmentIdentification);
		validator.Length(x => x.NumberOfPackages, 1, 8);
		return validator.Results;
	}
}
