using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G52")]
public class G52_PromotionAnnouncementConfirmationStatus : EdiX12Segment
{
	[Position(01)]
	public string PromotionConfirmationStatusCode { get; set; }

	[Position(02)]
	public string AllowanceOrChargeNumber { get; set; }

	[Position(03)]
	public string ChangeOrResponseTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G52_PromotionAnnouncementConfirmationStatus>(this);
		validator.Required(x=>x.PromotionConfirmationStatusCode);
		validator.Required(x=>x.ChangeOrResponseTypeCode);
		validator.Length(x => x.PromotionConfirmationStatusCode, 2);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		validator.Length(x => x.ChangeOrResponseTypeCode, 2);
		return validator.Results;
	}
}
