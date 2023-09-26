using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("TA1")]
public class TA1_InterchangeAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public int? InterchangeControlNumber { get; set; }

	[Position(02)]
	public string InterchangeDate { get; set; }

	[Position(03)]
	public string InterchangeTime { get; set; }

	[Position(04)]
	public string InterchangeAcknowledgmentCode { get; set; }

	[Position(05)]
	public string InterchangeNoteCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TA1_InterchangeAcknowledgment>(this);
		validator.Required(x=>x.InterchangeControlNumber);
		validator.Required(x=>x.InterchangeDate);
		validator.Required(x=>x.InterchangeTime);
		validator.Required(x=>x.InterchangeAcknowledgmentCode);
		validator.Required(x=>x.InterchangeNoteCode);
		validator.Length(x => x.InterchangeControlNumber, 9);
		validator.Length(x => x.InterchangeDate, 6);
		validator.Length(x => x.InterchangeTime, 4);
		validator.Length(x => x.InterchangeAcknowledgmentCode, 1);
		validator.Length(x => x.InterchangeNoteCode, 3);
		return validator.Results;
	}
}
