using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("LH3")]
public class LH3_HazardousMaterialShippingName : EdiX12Segment
{
	[Position(01)]
	public string HazardousMaterialShippingName { get; set; }

	[Position(02)]
	public string AdditionalHazardousInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH3_HazardousMaterialShippingName>(this);
		validator.Length(x => x.HazardousMaterialShippingName, 1, 50);
		validator.Length(x => x.AdditionalHazardousInformation, 1, 50);
		return validator.Results;
	}
}
