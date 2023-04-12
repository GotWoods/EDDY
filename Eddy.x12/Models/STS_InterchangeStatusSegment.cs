using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("STS")]
public class STS_InterchangeStatusSegment : EdiX12Segment
{
	[Position(01)]
	public string InterchangeActionCode { get; set; }

	[Position(02)]
	public string InterchangeActionDate { get; set; }

	[Position(03)]
	public string InterchangeActionTime { get; set; }

	[Position(04)]
	public string TimeCode { get; set; }

	[Position(05)]
	public string ErrorReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STS_InterchangeStatusSegment>(this);
		validator.Required(x=>x.InterchangeActionCode);
		validator.Required(x=>x.InterchangeActionDate);
		validator.Required(x=>x.InterchangeActionTime);
		validator.Length(x => x.InterchangeActionCode, 2);
		validator.Length(x => x.InterchangeActionDate, 6);
		validator.Length(x => x.InterchangeActionTime, 4, 6);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.ErrorReasonCode, 3);
		return validator.Results;
	}
}
