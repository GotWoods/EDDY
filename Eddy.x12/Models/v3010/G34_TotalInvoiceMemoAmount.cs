using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G34")]
public class G34_TotalInvoiceMemoAmount : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string TotalNetInvoicePayment { get; set; }

	[Position(04)]
	public string TotalInvoiceAmount { get; set; }

	[Position(05)]
	public string AmountSubjectToTermsDiscount { get; set; }

	[Position(06)]
	public string DiscountedAmountDue { get; set; }

	[Position(07)]
	public string TermsDiscountAmount { get; set; }

	[Position(08)]
	public string AmountOfAdjustment { get; set; }

	[Position(09)]
	public string AdjustmentReasonCode { get; set; }

	[Position(10)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G34_TotalInvoiceMemoAmount>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.TotalNetInvoicePayment, 2, 10);
		validator.Length(x => x.TotalInvoiceAmount, 1, 10);
		validator.Length(x => x.AmountSubjectToTermsDiscount, 1, 10);
		validator.Length(x => x.DiscountedAmountDue, 1, 10);
		validator.Length(x => x.TermsDiscountAmount, 1, 10);
		validator.Length(x => x.AmountOfAdjustment, 2, 10);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
