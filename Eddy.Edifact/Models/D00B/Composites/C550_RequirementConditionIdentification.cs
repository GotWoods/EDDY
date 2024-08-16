using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C550")]
public class C550_RequirementConditionIdentification : EdifactComponent
{
	[Position(1)]
	public string RequirementOrConditionDescriptionIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string RequirementOrConditionDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C550_RequirementConditionIdentification>(this);
		validator.Required(x=>x.RequirementOrConditionDescriptionIdentifier);
		validator.Length(x => x.RequirementOrConditionDescriptionIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.RequirementOrConditionDescription, 1, 35);
		return validator.Results;
	}
}
