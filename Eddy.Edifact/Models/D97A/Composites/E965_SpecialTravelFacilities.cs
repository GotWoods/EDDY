using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E965")]
public class E965_SpecialTravelFacilities : EdifactComponent
{
	[Position(1)]
	public string FacilityTypeCoded { get; set; }

	[Position(2)]
	public string FacilityTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E965_SpecialTravelFacilities>(this);
		validator.Length(x => x.FacilityTypeCoded, 1, 3);
		validator.Length(x => x.FacilityTypeDescription, 1, 70);
		return validator.Results;
	}
}