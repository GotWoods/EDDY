using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C812")]
public class C812_ResponseDetails : EdifactComponent
{
	[Position(1)]
	public string ResponseDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ResponseDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C812_ResponseDetails>(this);
		validator.Length(x => x.ResponseDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ResponseDescription, 1, 256);
		return validator.Results;
	}
}
