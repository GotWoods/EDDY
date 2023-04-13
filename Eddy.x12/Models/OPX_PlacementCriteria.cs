using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("OPX")]
public class OPX_PlacementCriteria : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string PlacementCriteriaCode { get; set; }

	[Position(03)]
	public string StatusReasonCode { get; set; }

	[Position(04)]
	public string EducationalTestOrRequirementCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OPX_PlacementCriteria>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.PlacementCriteriaCode, 1);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.EducationalTestOrRequirementCode, 1, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
