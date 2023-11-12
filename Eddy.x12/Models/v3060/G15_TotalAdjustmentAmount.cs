using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("G15")]
public class G15_CouponDistribution : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string CouponDistributionMediaCode { get; set; }

	[Position(03)]
	public string CouponTypeCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G15_CouponDistribution>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.CouponDistributionMediaCode);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.CouponDistributionMediaCode, 2);
		validator.Length(x => x.CouponTypeCode, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
