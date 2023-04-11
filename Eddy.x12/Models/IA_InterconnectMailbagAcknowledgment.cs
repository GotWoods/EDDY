using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("IA")]
public class IA_InterconnectMailbagAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public int? InterconnectMailbagControlNumber { get; set; }

	[Position(02)]
	public string InterconnectMailbagAcknowledgmentActionCode { get; set; }

	[Position(03)]
	public string InterconnectMailbagErrorCode { get; set; }

	[Position(04)]
	public string InterconnectMailbagErrorCode2 { get; set; }

	[Position(05)]
	public string InterconnectMailbagErrorCode3 { get; set; }

	[Position(06)]
	public string InterconnectMailbagErrorCode4 { get; set; }

	[Position(07)]
	public string InterconnectMailbagErrorCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IA_InterconnectMailbagAcknowledgment>(this);
		validator.Required(x=>x.InterconnectMailbagControlNumber);
		validator.Required(x=>x.InterconnectMailbagAcknowledgmentActionCode);
		validator.Length(x => x.InterconnectMailbagControlNumber, 1, 9);
		validator.Length(x => x.InterconnectMailbagAcknowledgmentActionCode, 1);
		validator.Length(x => x.InterconnectMailbagErrorCode, 2);
		validator.Length(x => x.InterconnectMailbagErrorCode2, 2);
		validator.Length(x => x.InterconnectMailbagErrorCode3, 2);
		validator.Length(x => x.InterconnectMailbagErrorCode4, 2);
		validator.Length(x => x.InterconnectMailbagErrorCode5, 2);
		return validator.Results;
	}
}
