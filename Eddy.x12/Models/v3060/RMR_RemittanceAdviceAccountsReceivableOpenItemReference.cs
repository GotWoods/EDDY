using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("RMR")]
public class RMR_RemittanceAdviceAccountsReceivableOpenItemReference : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string PaymentActionCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(07)]
	public string AdjustmentReasonCode { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AdjustmentReasonCode, x=>x.MonetaryAmount4);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.PaymentActionCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		return validator.Results;
	}
}
