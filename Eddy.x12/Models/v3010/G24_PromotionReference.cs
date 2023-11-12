using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G24")]
public class G24_PromotionReference : EdiX12Segment
{
	[Position(01)]
	public string AllowanceOrChargeNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G24_PromotionReference>(this);
		validator.Required(x=>x.AllowanceOrChargeNumber);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		return validator.Results;
	}
}
