using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("OPX")]
public class OPX_PlacementCriteria : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string PlacementCriteriaCode { get; set; }

	[Position(03)]
	public string StatusReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OPX_PlacementCriteria>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.PlacementCriteriaCode, 1);
		validator.Length(x => x.StatusReasonCode, 3);
		return validator.Results;
	}
}
