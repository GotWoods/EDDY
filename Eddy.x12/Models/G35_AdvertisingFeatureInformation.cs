using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G35")]
public class G35_AdvertisingFeatureInformation : EdiX12Segment
{
	[Position(01)]
	public string PromotionConditionCode { get; set; }

	[Position(02)]
	public string CouponTypeCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G35_AdvertisingFeatureInformation>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.MonetaryAmount, x=>x.PromotionConditionCode, x=>x.CouponTypeCode);
		validator.Length(x => x.PromotionConditionCode, 2);
		validator.Length(x => x.CouponTypeCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		return validator.Results;
	}
}
