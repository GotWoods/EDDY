using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C824")]
public class C824_ComponentMaterial : EdifactComponent
{
	[Position(1)]
	public string ComponentMaterialDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ComponentMaterialDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C824_ComponentMaterial>(this);
		validator.Length(x => x.ComponentMaterialDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ComponentMaterialDescription, 1, 35);
		return validator.Results;
	}
}
