using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("HCR")]
public class HCR_HealthCareServicesReview : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HCR_HealthCareServicesReview>(this);
		validator.Required(x=>x.ActionCode);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
