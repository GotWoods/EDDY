using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("RCS")]
public class RCS_RequirementsAndConditions : EdifactSegment
{
	[Position(1)]
	public string SectorSubjectIdentificationQualifier { get; set; }

	[Position(2)]
	public C550_RequirementConditionIdentification RequirementConditionIdentification { get; set; }

	[Position(3)]
	public string ActionRequestNotificationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RCS_RequirementsAndConditions>(this);
		validator.Required(x=>x.SectorSubjectIdentificationQualifier);
		validator.Length(x => x.SectorSubjectIdentificationQualifier, 1, 3);
		validator.Length(x => x.ActionRequestNotificationCoded, 1, 3);
		return validator.Results;
	}
}
