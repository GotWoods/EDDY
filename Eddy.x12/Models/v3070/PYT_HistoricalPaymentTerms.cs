using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("PYT")]
public class PYT_HistoricalPaymentTerms : EdiX12Segment
{
	[Position(01)]
	public int? TermsNetDays { get; set; }

	[Position(02)]
	public string TermsTypeCode { get; set; }

	[Position(03)]
	public int? DayOfMonth { get; set; }

	[Position(04)]
	public decimal? TermsDiscountPercent { get; set; }

	[Position(05)]
	public decimal? TermsDiscountPercent2 { get; set; }

	[Position(06)]
	public string TermsTypeCode2 { get; set; }

	[Position(07)]
	public int? TermsDiscountDaysDue { get; set; }

	[Position(08)]
	public int? TermsDiscountDaysDue2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PYT_HistoricalPaymentTerms>(this);
		validator.AtLeastOneIsRequired(x=>x.TermsNetDays, x=>x.TermsTypeCode);
		validator.ARequiresB(x=>x.DayOfMonth, x=>x.TermsTypeCode);
		validator.ARequiresB(x=>x.TermsDiscountPercent2, x=>x.TermsDiscountPercent);
		validator.ARequiresB(x=>x.TermsTypeCode2, x=>x.TermsDiscountPercent);
		validator.ARequiresB(x=>x.TermsDiscountDaysDue2, x=>x.TermsDiscountDaysDue);
		validator.Length(x => x.TermsNetDays, 1, 3);
		validator.Length(x => x.TermsTypeCode, 2);
		validator.Length(x => x.DayOfMonth, 1, 2);
		validator.Length(x => x.TermsDiscountPercent, 1, 6);
		validator.Length(x => x.TermsDiscountPercent2, 1, 6);
		validator.Length(x => x.TermsTypeCode2, 2);
		validator.Length(x => x.TermsDiscountDaysDue, 1, 3);
		validator.Length(x => x.TermsDiscountDaysDue2, 1, 3);
		return validator.Results;
	}
}
