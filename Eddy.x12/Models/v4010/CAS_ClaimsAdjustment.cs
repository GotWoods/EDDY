using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

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

	[Position(05)]
	public string ClaimAdjustmentReasonCode2 { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	[Position(08)]
	public string ClaimAdjustmentReasonCode3 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(10)]
	public decimal? Quantity3 { get; set; }

	[Position(11)]
	public string ClaimAdjustmentReasonCode4 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(13)]
	public decimal? Quantity4 { get; set; }

	[Position(14)]
	public string ClaimAdjustmentReasonCode5 { get; set; }

	[Position(15)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(16)]
	public decimal? Quantity5 { get; set; }

	[Position(17)]
	public string ClaimAdjustmentReasonCode6 { get; set; }

	[Position(18)]
	public decimal? MonetaryAmount6 { get; set; }

	[Position(19)]
	public decimal? Quantity6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAS_ClaimsAdjustment>(this);
		validator.Required(x=>x.ClaimAdjustmentGroupCode);
		validator.Required(x=>x.ClaimAdjustmentReasonCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ClaimAdjustmentReasonCode2, x=>x.MonetaryAmount2, x=>x.Quantity2);
		validator.ARequiresB(x=>x.MonetaryAmount2, x=>x.ClaimAdjustmentReasonCode2);
		validator.ARequiresB(x=>x.Quantity2, x=>x.ClaimAdjustmentReasonCode2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ClaimAdjustmentReasonCode3, x=>x.MonetaryAmount3, x=>x.Quantity3);
		validator.ARequiresB(x=>x.MonetaryAmount3, x=>x.ClaimAdjustmentReasonCode3);
		validator.ARequiresB(x=>x.Quantity3, x=>x.ClaimAdjustmentReasonCode3);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ClaimAdjustmentReasonCode4, x=>x.MonetaryAmount4, x=>x.Quantity4);
		validator.ARequiresB(x=>x.MonetaryAmount4, x=>x.ClaimAdjustmentReasonCode4);
		validator.ARequiresB(x=>x.Quantity4, x=>x.ClaimAdjustmentReasonCode4);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ClaimAdjustmentReasonCode5, x=>x.MonetaryAmount5, x=>x.Quantity5);
		validator.ARequiresB(x=>x.MonetaryAmount5, x=>x.ClaimAdjustmentReasonCode5);
		validator.ARequiresB(x=>x.Quantity5, x=>x.ClaimAdjustmentReasonCode5);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ClaimAdjustmentReasonCode6, x=>x.MonetaryAmount6, x=>x.Quantity6);
		validator.ARequiresB(x=>x.MonetaryAmount6, x=>x.ClaimAdjustmentReasonCode6);
		validator.ARequiresB(x=>x.Quantity6, x=>x.ClaimAdjustmentReasonCode6);
		validator.Length(x => x.ClaimAdjustmentGroupCode, 1, 2);
		validator.Length(x => x.ClaimAdjustmentReasonCode, 1, 5);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ClaimAdjustmentReasonCode2, 1, 5);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.ClaimAdjustmentReasonCode3, 1, 5);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.ClaimAdjustmentReasonCode4, 1, 5);
		validator.Length(x => x.MonetaryAmount4, 1, 18);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.ClaimAdjustmentReasonCode5, 1, 5);
		validator.Length(x => x.MonetaryAmount5, 1, 18);
		validator.Length(x => x.Quantity5, 1, 15);
		validator.Length(x => x.ClaimAdjustmentReasonCode6, 1, 5);
		validator.Length(x => x.MonetaryAmount6, 1, 18);
		validator.Length(x => x.Quantity6, 1, 15);
		return validator.Results;
	}
}
