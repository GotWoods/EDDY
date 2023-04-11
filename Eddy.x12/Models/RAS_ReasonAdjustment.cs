using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RAS")]
public class RAS_ReasonAdjustment : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public string ClaimAdjustmentGroupCode { get; set; }

	[Position(03)]
	public C058_AdjustmentReason AdjustmentReason { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RAS_ReasonAdjustment>(this);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.ClaimAdjustmentGroupCode);
		validator.Required(x=>x.AdjustmentReason);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ClaimAdjustmentGroupCode, 1, 10);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
