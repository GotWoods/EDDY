using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("C107")]
public class C107_TextReference : EdifactComponent
{
	[Position(1)]
	public string FreeTextDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C107_TextReference>(this);
		validator.Required(x=>x.FreeTextDescriptionCode);
		validator.Length(x => x.FreeTextDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
