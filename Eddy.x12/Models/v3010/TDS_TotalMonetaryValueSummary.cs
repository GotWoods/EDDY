using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TDS")]
public class TDS_TotalMonetaryValueSummary : EdiX12Segment
{
	[Position(01)]
	public string TotalInvoiceAmount { get; set; }

	[Position(02)]
	public string AmountSubjectToTermsDiscount { get; set; }

	[Position(03)]
	public string DiscountedAmountDue { get; set; }

	[Position(04)]
	public string TermsDiscountAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TDS_TotalMonetaryValueSummary>(this);
		validator.Required(x=>x.TotalInvoiceAmount);
		validator.Length(x => x.TotalInvoiceAmount, 1, 10);
		validator.Length(x => x.AmountSubjectToTermsDiscount, 1, 10);
		validator.Length(x => x.DiscountedAmountDue, 1, 10);
		validator.Length(x => x.TermsDiscountAmount, 1, 10);
		return validator.Results;
	}
}
