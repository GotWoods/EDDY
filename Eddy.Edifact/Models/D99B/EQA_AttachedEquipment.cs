using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("EQA")]
public class EQA_AttachedEquipment : EdifactSegment
{
	[Position(1)]
	public string EquipmentTypeCodeQualifier { get; set; }

	[Position(2)]
	public C237_EquipmentIdentification EquipmentIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQA_AttachedEquipment>(this);
		validator.Required(x=>x.EquipmentTypeCodeQualifier);
		validator.Length(x => x.EquipmentTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
