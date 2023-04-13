using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G42")]
public class G42_PromotionAnnouncementIdentification : EdiX12Segment
{
	[Position(01)]
	public string PromotionStatusCode { get; set; }

	[Position(02)]
	public string AllowanceOrChargeNumber { get; set; }

	[Position(03)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G42_PromotionAnnouncementIdentification>(this);
		validator.Required(x=>x.PromotionStatusCode);
		validator.Required(x=>x.AllowanceOrChargeNumber);
		validator.Length(x => x.PromotionStatusCode, 2);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
