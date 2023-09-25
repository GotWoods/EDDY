using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("OPS")]
public class OPS_OtherProgramSubjectAreaAndEligibility : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string PlacementCriteriaCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OPS_OtherProgramSubjectAreaAndEligibility>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.PlacementCriteriaCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
