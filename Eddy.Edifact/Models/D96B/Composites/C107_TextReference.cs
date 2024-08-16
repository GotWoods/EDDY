using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C107")]
public class C107_TextReference : EdifactComponent
{
	[Position(1)]
	public string FreeTextIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C107_TextReference>(this);
		validator.Required(x=>x.FreeTextIdentification);
		validator.Length(x => x.FreeTextIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
