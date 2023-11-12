using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SSE")]
public class SSE_EntryAndExitInformation : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string Date2 { get; set; }

	[Position(03)]
	public string StatusReasonCode { get; set; }

	[Position(04)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SSE_EntryAndExitInformation>(this);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
