using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G44")]
public class G44_PromotionRestrictions : EdiX12Segment
{
	[Position(01)]
	public string PromotionConditionQualifier { get; set; }

	[Position(02)]
	public string PromotionConditionCode { get; set; }

	[Position(03)]
	public string PromotionConditionCode2 { get; set; }

	[Position(04)]
	public string PromotionConditionCode3 { get; set; }

	[Position(05)]
	public string PromotionConditionCode4 { get; set; }

	[Position(06)]
	public string FreeFormMessage { get; set; }

	[Position(07)]
	public string FreeFormMessage2 { get; set; }

	[Position(08)]
	public string PromotionAmountQualifier { get; set; }

	[Position(09)]
	public string AllowanceOrChargeTotalAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G44_PromotionRestrictions>(this);
		validator.Required(x=>x.PromotionConditionQualifier);
		validator.Length(x => x.PromotionConditionQualifier, 2);
		validator.Length(x => x.PromotionConditionCode, 2);
		validator.Length(x => x.PromotionConditionCode2, 2);
		validator.Length(x => x.PromotionConditionCode3, 2);
		validator.Length(x => x.PromotionConditionCode4, 2);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.FreeFormMessage2, 1, 60);
		validator.Length(x => x.PromotionAmountQualifier, 2);
		validator.Length(x => x.AllowanceOrChargeTotalAmount, 1, 9);
		return validator.Results;
	}
}
