using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98A.Composites;

[Segment("E006")]
public class E006_RuleStatus : EdifactComponent
{
	[Position(1)]
	public string SpecialConditionsCoded { get; set; }

	[Position(2)]
	public string ProcessingIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E006_RuleStatus>(this);
		validator.Required(x=>x.SpecialConditionsCoded);
		validator.Length(x => x.SpecialConditionsCoded, 1, 3);
		validator.Length(x => x.ProcessingIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
