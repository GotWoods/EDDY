using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("RIC")]
public class RIC_FinancialReturn : EdiX12Segment
{
	[Position(01)]
	public string ApplicationErrorConditionCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string CreditDebitFlagCode { get; set; }

	[Position(04)]
	public string AccountNumber { get; set; }

	[Position(05)]
	public string AccountNumberQualifier { get; set; }

	[Position(06)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(07)]
	public string DFIIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RIC_FinancialReturn>(this);
		validator.Required(x=>x.ApplicationErrorConditionCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.ARequiresB(x=>x.AccountNumberQualifier, x=>x.AccountNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier, x=>x.DFIIdentificationNumber);
		validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.AccountNumberQualifier, 1, 3);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		return validator.Results;
	}
}
