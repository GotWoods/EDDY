using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C550")]
public class C550_RequirementConditionIdentification : EdifactComponent
{
	[Position(1)]
	public string RequirementConditionIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string RequirementOrCondition { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C550_RequirementConditionIdentification>(this);
		validator.Required(x=>x.RequirementConditionIdentification);
		validator.Length(x => x.RequirementConditionIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.RequirementOrCondition, 1, 35);
		return validator.Results;
	}
}
