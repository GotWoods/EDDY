using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C824")]
public class C824_ComponentMaterial : EdifactComponent
{
	[Position(1)]
	public string ComponentMaterialCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ComponentMaterial { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C824_ComponentMaterial>(this);
		validator.Length(x => x.ComponentMaterialCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ComponentMaterial, 1, 35);
		return validator.Results;
	}
}
