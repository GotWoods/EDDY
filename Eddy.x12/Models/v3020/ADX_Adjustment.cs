using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("ADX")]
public class ADX_Adjustment : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public string AdjustmentReasonCode { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ADX_Adjustment>(this);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.AdjustmentReasonCode);
		validator.ARequiresB(x=>x.ReferenceNumber, x=>x.ReferenceNumberQualifier);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
