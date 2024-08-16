using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("PRO")]
public class PRO_Promotions : EdifactSegment
{
	[Position(1)]
	public E019_PromotionDetails PromotionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRO_Promotions>(this);
		validator.Required(x=>x.PromotionDetails);
		return validator.Results;
	}
}
