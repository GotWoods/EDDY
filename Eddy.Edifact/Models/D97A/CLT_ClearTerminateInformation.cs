using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("CLT")]
public class CLT_ClearTerminateInformation : EdifactSegment
{
	[Position(1)]
	public string ActionRequestNotificationCoded { get; set; }

	[Position(2)]
	public string MessageFunctionCoded { get; set; }

	[Position(3)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLT_ClearTerminateInformation>(this);
		validator.Required(x=>x.ActionRequestNotificationCoded);
		validator.Length(x => x.ActionRequestNotificationCoded, 1, 3);
		validator.Length(x => x.MessageFunctionCoded, 1, 3);
		validator.Length(x => x.FreeText, 1, 70);
		return validator.Results;
	}
}
