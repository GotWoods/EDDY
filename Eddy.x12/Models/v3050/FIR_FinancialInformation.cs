using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("FIR")]
public class FIR_FinancialInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string FinancialInformationCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string TimeCode { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public decimal? Quantity2 { get; set; }

	[Position(09)]
	public string CreditDebitFlagCode { get; set; }

	[Position(10)]
	public string FinancialTransactionStatusCode { get; set; }

	[Position(11)]
	public string CurrencyCode { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FIR_FinancialInformation>(this);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Required(x=>x.FinancialInformationCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CurrencyCode, x=>x.MonetaryAmount2);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.FinancialInformationCode, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.FinancialTransactionStatusCode, 1, 2);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		return validator.Results;
	}
}
