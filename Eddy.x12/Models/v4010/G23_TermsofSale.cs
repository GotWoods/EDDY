using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("G23")]
public class G23_TermsOfSale : EdiX12Segment
{
	[Position(01)]
	public string TermsTypeCode { get; set; }

	[Position(02)]
	public string TermsBasisDateCode { get; set; }

	[Position(03)]
	public string TermsStartDate { get; set; }

	[Position(04)]
	public string TermsDueDateQualifier { get; set; }

	[Position(05)]
	public decimal? TermsDiscountPercent { get; set; }

	[Position(06)]
	public string TermsDiscountDueDate { get; set; }

	[Position(07)]
	public int? TermsDiscountDaysDue { get; set; }

	[Position(08)]
	public string TermsNetDueDate { get; set; }

	[Position(09)]
	public int? TermsNetDays { get; set; }

	[Position(10)]
	public string TermsDiscountAmount { get; set; }

	[Position(11)]
	public string DiscountedAmountDue { get; set; }

	[Position(12)]
	public string AmountSubjectToTermsDiscount { get; set; }

	[Position(13)]
	public string InstallmentTotalInvoiceAmountDue { get; set; }

	[Position(14)]
	public decimal? PercentOfInvoicePayable { get; set; }

	[Position(15)]
	public string FreeFormMessage { get; set; }

	[Position(16)]
	public int? InstallmentGroupIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G23_TermsOfSale>(this);
		validator.Required(x=>x.TermsTypeCode);
		validator.Required(x=>x.TermsBasisDateCode);
		validator.AtLeastOneIsRequired(x=>x.TermsNetDueDate, x=>x.TermsNetDays);
		validator.Length(x => x.TermsTypeCode, 2);
		validator.Length(x => x.TermsBasisDateCode, 1, 2);
		validator.Length(x => x.TermsStartDate, 8);
		validator.Length(x => x.TermsDueDateQualifier, 2);
		validator.Length(x => x.TermsDiscountPercent, 1, 6);
		validator.Length(x => x.TermsDiscountDueDate, 8);
		validator.Length(x => x.TermsDiscountDaysDue, 1, 3);
		validator.Length(x => x.TermsNetDueDate, 8);
		validator.Length(x => x.TermsNetDays, 1, 3);
		validator.Length(x => x.TermsDiscountAmount, 1, 10);
		validator.Length(x => x.DiscountedAmountDue, 1, 10);
		validator.Length(x => x.AmountSubjectToTermsDiscount, 1, 10);
		validator.Length(x => x.InstallmentTotalInvoiceAmountDue, 1, 10);
		validator.Length(x => x.PercentOfInvoicePayable, 1, 5);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.InstallmentGroupIndicator, 2);
		return validator.Results;
	}
}
