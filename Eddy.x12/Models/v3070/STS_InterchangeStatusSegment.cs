using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("STS")]
public class STS_InterchangeStatusSegment : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string ActionDate { get; set; }

	[Position(03)]
	public string ActionTime { get; set; }

	[Position(04)]
	public string TimeCode { get; set; }

	[Position(05)]
	public int? Century { get; set; }

	[Position(06)]
	public string ErrorReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STS_InterchangeStatusSegment>(this);
		validator.Required(x=>x.ActionCode);
		validator.Required(x=>x.ActionDate);
		validator.Required(x=>x.ActionTime);
		validator.Length(x => x.ActionCode, 2);
		validator.Length(x => x.ActionDate, 6);
		validator.Length(x => x.ActionTime, 4, 6);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.ErrorReasonCode, 3);
		return validator.Results;
	}
}
