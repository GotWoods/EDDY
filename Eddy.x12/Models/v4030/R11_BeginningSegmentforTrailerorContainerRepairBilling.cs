using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("R11")]
public class R11_BeginningSegmentForTrailerOrContainerRepairBilling : EdiX12Segment
{
	[Position(01)]
	public string TransactionTypeCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(04)]
	public string InvoiceNumber { get; set; }

	[Position(05)]
	public string MonthOfTheYearCode { get; set; }

	[Position(06)]
	public int? Year { get; set; }

	[Position(07)]
	public string TermsTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R11_BeginningSegmentForTrailerOrContainerRepairBilling>(this);
		validator.Required(x=>x.TransactionTypeCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.MonthOfTheYearCode);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.MonthOfTheYearCode, 2);
		validator.Length(x => x.Year, 4);
		validator.Length(x => x.TermsTypeCode, 2);
		return validator.Results;
	}
}
