using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("FIR")]
public class FIR_FinancialInformation : EdiX12Segment
{
	[Position(01)]
	public string FinancialTransactionCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? Quantity2 { get; set; }

	[Position(05)]
	public string FinancialInformationTypeCode { get; set; }

	[Position(06)]
	public string CreditDebitFlagCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string Time { get; set; }

	[Position(09)]
	public string TimeCode { get; set; }

	[Position(10)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FIR_FinancialInformation>(this);
		validator.Required(x=>x.FinancialTransactionCode);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.FinancialTransactionCode, 6);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.FinancialInformationTypeCode, 1);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
