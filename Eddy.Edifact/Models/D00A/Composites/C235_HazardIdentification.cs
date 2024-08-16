using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C235")]
public class C235_HazardIdentificationPlacardDetails : EdifactComponent
{
	[Position(1)]
	public string OrangeHazardPlacardUpperPartIdentifier { get; set; }

	[Position(2)]
	public string OrangeHazardPlacardLowerPartIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C235_HazardIdentificationPlacardDetails>(this);
		validator.Length(x => x.OrangeHazardPlacardUpperPartIdentifier, 1, 4);
		validator.Length(x => x.OrangeHazardPlacardLowerPartIdentifier, 4);
		return validator.Results;
	}
}
