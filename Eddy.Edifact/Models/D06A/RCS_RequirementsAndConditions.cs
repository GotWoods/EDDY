using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Models.D06A;

[Segment("RCS")]
public class RCS_RequirementsAndConditions : EdifactSegment
{
	[Position(1)]
	public string SectorAreaIdentificationCodeQualifier { get; set; }

	[Position(2)]
	public C550_RequirementConditionIdentification RequirementConditionIdentification { get; set; }

	[Position(3)]
	public string ActionCode { get; set; }

	[Position(4)]
	public string CountryIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RCS_RequirementsAndConditions>(this);
		validator.Required(x=>x.SectorAreaIdentificationCodeQualifier);
		validator.Length(x => x.SectorAreaIdentificationCodeQualifier, 1, 3);
		validator.Length(x => x.ActionCode, 1, 3);
		validator.Length(x => x.CountryIdentifier, 1, 3);
		return validator.Results;
	}
}
