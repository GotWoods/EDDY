using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("CLT")]
public class CLT_ClearTerminateInformation : EdifactSegment
{
	[Position(1)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(2)]
	public string MessageFunctionCode { get; set; }

	[Position(3)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLT_ClearTerminateInformation>(this);
		validator.Required(x=>x.ActionRequestNotificationDescriptionCode);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		validator.Length(x => x.MessageFunctionCode, 1, 3);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
