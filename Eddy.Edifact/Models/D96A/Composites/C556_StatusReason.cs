using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C556")]
public class C556_StatusReason : EdifactComponent
{
	[Position(1)]
	public string StatusReasonCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string StatusReason { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C556_StatusReason>(this);
		validator.Required(x=>x.StatusReasonCoded);
		validator.Length(x => x.StatusReasonCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.StatusReason, 1, 35);
		return validator.Results;
	}
}
