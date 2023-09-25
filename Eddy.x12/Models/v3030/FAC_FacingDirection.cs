using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("FAC")]
public class FAC_FacingDirection : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(04)]
	public string DirectionFacing { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FAC_FacingDirection>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.Required(x=>x.DirectionFacing);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.DirectionFacing, 1);
		return validator.Results;
	}
}
