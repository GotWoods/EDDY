using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PCC")]
public class PCC_PremiumCalculationComponentDetails : EdifactSegment
{
	[Position(1)]
	public C820_PremiumCalculationComponent PremiumCalculationComponent { get; set; }

	[Position(2)]
	public string PremiumCalculationComponentValueCategoryIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCC_PremiumCalculationComponentDetails>(this);
		validator.Length(x => x.PremiumCalculationComponentValueCategoryIdentifier, 1, 35);
		return validator.Results;
	}
}
