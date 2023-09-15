using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("BNR")]
public class BNR_BeginningSegmentForNonconformanceReport : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string NonconformanceReportStatusCode { get; set; }

	[Position(06)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BNR_BeginningSegmentForNonconformanceReport>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.NonconformanceReportStatusCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
