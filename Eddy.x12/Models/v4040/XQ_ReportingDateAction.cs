using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("XQ")]
public class XQ_ReportingDateAction : EdiX12Segment
{
	[Position(01)]
	public string TransactionHandlingCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XQ_ReportingDateAction>(this);
		validator.Required(x=>x.TransactionHandlingCode);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionHandlingCode, 1, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}
