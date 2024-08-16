using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C246")]
public class C246_CustomsIdentityCodes : EdifactComponent
{
	[Position(1)]
	public string CustomsCodeIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C246_CustomsIdentityCodes>(this);
		validator.Required(x=>x.CustomsCodeIdentification);
		validator.Length(x => x.CustomsCodeIdentification, 1, 18);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
