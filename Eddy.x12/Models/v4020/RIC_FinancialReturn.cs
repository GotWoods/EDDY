using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("RIC")]
public class RIC_FinancialReturn : EdiX12Segment
{
	[Position(01)]
	public string PaymentMethodCode { get; set; }

	[Position(02)]
	public string CodeListQualifierCode { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string CreditDebitFlagCode { get; set; }

	[Position(06)]
	public string AccountNumber { get; set; }

	[Position(07)]
	public string AccountNumberQualifier { get; set; }

	[Position(08)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(09)]
	public string DFIIdentificationNumber { get; set; }

	[Position(10)]
	public string AccountNumber2 { get; set; }

	[Position(11)]
	public string AccountNumberQualifier2 { get; set; }

	[Position(12)]
	public string DFIIDNumberQualifier2 { get; set; }

	[Position(13)]
	public string DFIIdentificationNumber2 { get; set; }

	[Position(14)]
	public string AccountNumber3 { get; set; }

	[Position(15)]
	public string AccountNumberQualifier3 { get; set; }

	[Position(16)]
	public string DFIIDNumberQualifier3 { get; set; }

	[Position(17)]
	public string DFIIdentificationNumber3 { get; set; }

	[Position(18)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RIC_FinancialReturn>(this);
		validator.Required(x=>x.PaymentMethodCode);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Required(x=>x.IndustryCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.ARequiresB(x=>x.AccountNumberQualifier, x=>x.AccountNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier, x=>x.DFIIdentificationNumber);
		validator.ARequiresB(x=>x.AccountNumberQualifier2, x=>x.AccountNumber2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier2, x=>x.DFIIdentificationNumber2);
		validator.ARequiresB(x=>x.AccountNumberQualifier3, x=>x.AccountNumber3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier3, x=>x.DFIIdentificationNumber3);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.AccountNumberQualifier, 1, 3);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumber2, 1, 35);
		validator.Length(x => x.AccountNumberQualifier2, 1, 3);
		validator.Length(x => x.DFIIDNumberQualifier2, 2);
		validator.Length(x => x.DFIIdentificationNumber2, 3, 12);
		validator.Length(x => x.AccountNumber3, 1, 35);
		validator.Length(x => x.AccountNumberQualifier3, 1, 3);
		validator.Length(x => x.DFIIDNumberQualifier3, 2);
		validator.Length(x => x.DFIIdentificationNumber3, 3, 12);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
