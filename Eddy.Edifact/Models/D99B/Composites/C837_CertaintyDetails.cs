using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C837")]
public class C837_CertaintyDetails : EdifactComponent
{
	[Position(1)]
	public string CertaintyCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string Certainty { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C837_CertaintyDetails>(this);
		validator.Length(x => x.CertaintyCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.Certainty, 1, 35);
		return validator.Results;
	}
}