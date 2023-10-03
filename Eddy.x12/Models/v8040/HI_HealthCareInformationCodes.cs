using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040.Composites;

namespace Eddy.x12.Models.v8040;

[Segment("HI")]
public class HI_HealthCareInformationCodes : EdiX12Segment
{
	[Position(01)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HI_HealthCareInformationCodes>(this);
		validator.Required(x=>x.HealthCareCodeInformation);
		return validator.Results;
	}
}
