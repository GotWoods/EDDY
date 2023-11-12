using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("CAS")]
public class CAS_ClaimsAdjustment : EdiX12Segment
{
	[Position(01)]
	public string ClaimAdjustmentGroupCode { get; set; }

	[Position(02)]
	public string ClaimAdjustmentReasonCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAS_ClaimsAdjustment>(this);
		validator.Required(x=>x.ClaimAdjustmentGroupCode);
		validator.Required(x=>x.ClaimAdjustmentReasonCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.ClaimAdjustmentGroupCode, 1, 2);
		validator.Length(x => x.ClaimAdjustmentReasonCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
