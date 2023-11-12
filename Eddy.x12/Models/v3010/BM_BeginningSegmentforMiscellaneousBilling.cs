using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BM")]
public class BM_BeginningSegmentForMiscellaneousBilling : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string BillingDate { get; set; }

	[Position(03)]
	public string NetAmountDue { get; set; }

	[Position(04)]
	public string CorrectionIndicator { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string BillingCode { get; set; }

	[Position(07)]
	public int? AssignedNumber { get; set; }

	[Position(08)]
	public int? SequenceNumberQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BM_BeginningSegmentForMiscellaneousBilling>(this);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.BillingDate);
		validator.Required(x=>x.NetAmountDue);
		validator.Required(x=>x.BillingCode);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.BillingDate, 6);
		validator.Length(x => x.NetAmountDue, 1, 9);
		validator.Length(x => x.CorrectionIndicator, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.BillingCode, 1);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.SequenceNumberQualifier, 1);
		return validator.Results;
	}
}
