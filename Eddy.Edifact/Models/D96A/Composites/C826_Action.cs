using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C826")]
public class C826_Action : EdifactComponent
{
	[Position(1)]
	public string ActionRequestNotificationCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ActionRequestNotification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C826_Action>(this);
		validator.Length(x => x.ActionRequestNotificationCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ActionRequestNotification, 1, 35);
		return validator.Results;
	}
}
