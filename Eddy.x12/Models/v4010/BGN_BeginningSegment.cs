using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BGN")]
public class BGN_BeginningSegment : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string TimeCode { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string TransactionTypeCode { get; set; }

	[Position(08)]
	public string ActionCode { get; set; }

	[Position(09)]
	public string SecurityLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BGN_BeginningSegment>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.SecurityLevelCode, 2);
		return validator.Results;
	}
}
