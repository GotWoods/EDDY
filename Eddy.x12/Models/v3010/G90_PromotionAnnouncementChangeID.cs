using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G90")]
public class G90_PromotionAnnouncementChangeID : EdiX12Segment
{
	[Position(01)]
	public string ChangeTypeCode { get; set; }

	[Position(02)]
	public string AllowanceOrChargeNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G90_PromotionAnnouncementChangeID>(this);
		validator.Required(x=>x.ChangeTypeCode);
		validator.Required(x=>x.AllowanceOrChargeNumber);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		return validator.Results;
	}
}
