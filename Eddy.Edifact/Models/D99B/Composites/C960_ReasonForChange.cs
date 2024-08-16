using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C960")]
public class C960_ReasonForChange : EdifactComponent
{
	[Position(1)]
	public string ChangeReasonDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ChangeReasonDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C960_ReasonForChange>(this);
		validator.Length(x => x.ChangeReasonDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ChangeReasonDescription, 1, 35);
		return validator.Results;
	}
}
