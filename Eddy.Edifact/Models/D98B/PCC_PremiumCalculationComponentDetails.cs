using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("PCC")]
public class PCC_PremiumCalculationComponentDetails : EdifactSegment
{
	[Position(1)]
	public C820_PremiumCalculationComponent PremiumCalculationComponent { get; set; }

	[Position(2)]
	public string PremiumCalculationComponentValueCategory { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCC_PremiumCalculationComponentDetails>(this);
		validator.Length(x => x.PremiumCalculationComponentValueCategory, 1, 35);
		return validator.Results;
	}
}
