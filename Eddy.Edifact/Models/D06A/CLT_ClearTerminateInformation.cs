using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Models.D06A;

[Segment("CLT")]
public class CLT_ClearTerminateInformation : EdifactSegment
{
	[Position(1)]
	public string ActionCode { get; set; }

	[Position(2)]
	public string MessageFunctionCode { get; set; }

	[Position(3)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLT_ClearTerminateInformation>(this);
		validator.Required(x=>x.ActionCode);
		validator.Length(x => x.ActionCode, 1, 3);
		validator.Length(x => x.MessageFunctionCode, 1, 3);
		validator.Length(x => x.FreeText, 1, 512);
		return validator.Results;
	}
}
