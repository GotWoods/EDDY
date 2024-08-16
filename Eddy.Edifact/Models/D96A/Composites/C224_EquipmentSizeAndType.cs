using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C224")]
public class C224_EquipmentSizeAndType : EdifactComponent
{
	[Position(1)]
	public string EquipmentSizeAndTypeIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string EquipmentSizeAndType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C224_EquipmentSizeAndType>(this);
		validator.Length(x => x.EquipmentSizeAndTypeIdentification, 1, 10);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.EquipmentSizeAndType, 1, 35);
		return validator.Results;
	}
}
