using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("RMR")]
public class RMR_RemittanceAdviceAccountsReceivableOpenItemReference : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string PaymentActionCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public decimal? TotalInvoiceOrCreditDebitAmount { get; set; }

	[Position(06)]
	public decimal? AmountOfDiscountTaken { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.PaymentActionCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.TotalInvoiceOrCreditDebitAmount, 1, 15);
		validator.Length(x => x.AmountOfDiscountTaken, 1, 15);
		return validator.Results;
	}
}
