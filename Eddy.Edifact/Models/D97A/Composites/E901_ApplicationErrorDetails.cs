using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E901")]
public class E901_ApplicationErrorDetails : EdifactComponent
{
	[Position(1)]
	public string ApplicationErrorIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E901_ApplicationErrorDetails>(this);
		validator.Required(x=>x.ApplicationErrorIdentification);
		validator.Length(x => x.ApplicationErrorIdentification, 1, 8);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
