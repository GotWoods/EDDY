using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G94")]
public class G94_PromotionConditions : EdiX12Segment
{
	[Position(01)]
	public string PromotionConditionQualifier { get; set; }

	[Position(02)]
	public string OptionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G94_PromotionConditions>(this);
		validator.Required(x=>x.OptionNumber);
		validator.Length(x => x.PromotionConditionQualifier, 2);
		validator.Length(x => x.OptionNumber, 1, 20);
		return validator.Results;
	}
}
