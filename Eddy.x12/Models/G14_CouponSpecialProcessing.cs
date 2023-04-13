using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G14")]
public class G14_CouponSpecialProcessing : EdiX12Segment
{
	[Position(01)]
	public string ServicePromotionAllowanceOrChargeCode { get; set; }

	[Position(02)]
	public string ServicePromotionAllowanceOrChargeCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G14_CouponSpecialProcessing>(this);
		validator.Required(x=>x.ServicePromotionAllowanceOrChargeCode);
		validator.Length(x => x.ServicePromotionAllowanceOrChargeCode, 4);
		validator.Length(x => x.ServicePromotionAllowanceOrChargeCode2, 4);
		return validator.Results;
	}
}
