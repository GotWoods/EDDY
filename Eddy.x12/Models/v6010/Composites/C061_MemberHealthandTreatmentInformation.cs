using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010.Composites;

[Segment("C061")]
public class C061_MemberHealthAndTreatmentInformation : EdiX12Component
{
	[Position(00)]
	public string HealthRelatedCode { get; set; }

	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C061_MemberHealthAndTreatmentInformation>(this);
		validator.Length(x => x.HealthRelatedCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
