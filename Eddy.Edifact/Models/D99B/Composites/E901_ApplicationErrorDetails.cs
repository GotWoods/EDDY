using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E901")]
public class E901_ApplicationErrorDetails : EdifactComponent
{
	[Position(1)]
	public string ApplicationErrorIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E901_ApplicationErrorDetails>(this);
		validator.Required(x=>x.ApplicationErrorIdentification);
		validator.Length(x => x.ApplicationErrorIdentification, 1, 8);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
