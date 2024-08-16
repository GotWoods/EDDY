using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("EQA")]
public class EQA_AttachedEquipment : EdifactSegment
{
	[Position(1)]
	public string EquipmentQualifier { get; set; }

	[Position(2)]
	public C237_EquipmentIdentification EquipmentIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQA_AttachedEquipment>(this);
		validator.Required(x=>x.EquipmentQualifier);
		validator.Length(x => x.EquipmentQualifier, 1, 3);
		return validator.Results;
	}
}
