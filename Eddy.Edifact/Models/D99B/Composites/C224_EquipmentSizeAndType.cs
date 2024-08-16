using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C224")]
public class C224_EquipmentSizeAndType : EdifactComponent
{
	[Position(1)]
	public string EquipmentSizeAndTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string EquipmentSizeAndTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C224_EquipmentSizeAndType>(this);
		validator.Length(x => x.EquipmentSizeAndTypeDescriptionCode, 1, 10);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.EquipmentSizeAndTypeDescription, 1, 35);
		return validator.Results;
	}
}
