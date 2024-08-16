using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C556")]
public class C556_StatusReason : EdifactComponent
{
	[Position(1)]
	public string StatusReasonDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string StatusReasonDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C556_StatusReason>(this);
		validator.Required(x=>x.StatusReasonDescriptionCode);
		validator.Length(x => x.StatusReasonDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.StatusReasonDescription, 1, 256);
		return validator.Results;
	}
}
