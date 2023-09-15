using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ITD")]
public class ITD_TermsOfSaleDeferredTermsOfSale : EdiX12Segment
{
	[Position(01)]
	public string TermsTypeCode { get; set; }

	[Position(02)]
	public string TermsBasisDateCode { get; set; }

	[Position(03)]
	public decimal? TermsDiscountPercent { get; set; }

	[Position(04)]
	public string TermsDiscountDueDate { get; set; }

	[Position(05)]
	public int? TermsDiscountDaysDue { get; set; }

	[Position(06)]
	public string TermsNetDueDate { get; set; }

	[Position(07)]
	public int? TermsNetDays { get; set; }

	[Position(08)]
	public string TermsDiscountAmount { get; set; }

	[Position(09)]
	public string TermsDeferredDueDate { get; set; }

	[Position(10)]
	public string DeferredAmountDue { get; set; }

	[Position(11)]
	public decimal? PercentOfInvoicePayable { get; set; }

	[Position(12)]
	public string Description { get; set; }

	[Position(13)]
	public int? DayOfMonth { get; set; }

	[Position(14)]
	public string PaymentMethodCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITD_TermsOfSaleDeferredTermsOfSale>(this);
		validator.Length(x => x.TermsTypeCode, 2);
		validator.Length(x => x.TermsBasisDateCode, 1, 2);
		validator.Length(x => x.TermsDiscountPercent, 1, 6);
		validator.Length(x => x.TermsDiscountDueDate, 6);
		validator.Length(x => x.TermsDiscountDaysDue, 1, 3);
		validator.Length(x => x.TermsNetDueDate, 6);
		validator.Length(x => x.TermsNetDays, 1, 3);
		validator.Length(x => x.TermsDiscountAmount, 1, 10);
		validator.Length(x => x.TermsDeferredDueDate, 6);
		validator.Length(x => x.DeferredAmountDue, 1, 10);
		validator.Length(x => x.PercentOfInvoicePayable, 1, 5);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.DayOfMonth, 1, 2);
		validator.Length(x => x.PaymentMethodCode, 1);
		return validator.Results;
	}
}
