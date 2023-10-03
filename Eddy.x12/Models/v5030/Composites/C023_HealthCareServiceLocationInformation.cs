using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030.Composites;

[Segment("C023")]
public class C023_HealthCareServiceLocationInformation : EdiX12Component
{
	[Position(00)]
	public string FacilityCodeValue { get; set; }

	[Position(01)]
	public string FacilityCodeQualifier { get; set; }

	[Position(02)]
	public string ClaimFrequencyTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C023_HealthCareServiceLocationInformation>(this);
		validator.Required(x=>x.FacilityCodeValue);
		validator.Length(x => x.FacilityCodeValue, 1, 3);
		validator.Length(x => x.FacilityCodeQualifier, 1, 2);
		validator.Length(x => x.ClaimFrequencyTypeCode, 1);
		return validator.Results;
	}
}
