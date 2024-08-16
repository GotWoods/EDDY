using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("BGM")]
public class BGM_BeginningOfMessage : EdifactSegment
{
	[Position(1)]
	public C002_DocumentMessageName DocumentMessageName { get; set; }

	[Position(2)]
	public string DocumentMessageNumber { get; set; }

	[Position(3)]
	public string MessageFunctionCoded { get; set; }

	[Position(4)]
	public string ResponseTypeCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BGM_BeginningOfMessage>(this);
		validator.Length(x => x.DocumentMessageNumber, 1, 35);
		validator.Length(x => x.MessageFunctionCoded, 1, 3);
		validator.Length(x => x.ResponseTypeCoded, 1, 3);
		return validator.Results;
	}
}
