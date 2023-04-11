using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PDL")]
public class PDL_PaymentDetails : EdiX12Segment
{
	[Position(01)]
	public string PaymentMethodCode { get; set; }

	[Position(02)]
	public string AmountQualifierCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(05)]
	public string CreditDebitFlagCode { get; set; }

	[Position(06)]
	public string FrequencyCode { get; set; }

	[Position(07)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(08)]
	public string DFIIdentificationNumber { get; set; }

	[Position(09)]
	public string AccountNumberQualifier { get; set; }

	[Position(10)]
	public string AccountNumber { get; set; }

	[Position(11)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(12)]
	public string DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDL_PaymentDetails>(this);
		validator.Required(x=>x.PaymentMethodCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.OnlyOneOf(x=>x.MonetaryAmount, x=>x.PercentageAsDecimal);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier, x=>x.DFIIdentificationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AccountNumberQualifier, x=>x.AccountNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumberQualifier, 1, 3);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
