using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C812")]
public class C812_ResponseDetails : EdifactComponent
{
	[Position(1)]
	public string ResponseCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string Response { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C812_ResponseDetails>(this);
		validator.Length(x => x.ResponseCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.Response, 1, 256);
		return validator.Results;
	}
}
