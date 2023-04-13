using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

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
	public string DirectionFacingCode { get; set; }

	[Position(05)]
	public string EquipmentStatusCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FAC_FacingDirection>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.DirectionFacingCode, 1);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
