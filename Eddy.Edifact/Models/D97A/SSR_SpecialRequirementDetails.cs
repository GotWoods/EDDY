using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("SSR")]
public class SSR_SpecialRequirementDetails : EdifactSegment
{
	[Position(1)]
	public E980_SpecialRequirementTypeDetails SpecialRequirementTypeDetails { get; set; }

	[Position(2)]
	public E981_SpecialRequirementDetails SpecialRequirementDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SSR_SpecialRequirementDetails>(this);
		validator.Required(x=>x.SpecialRequirementTypeDetails);
		return validator.Results;
	}
}
