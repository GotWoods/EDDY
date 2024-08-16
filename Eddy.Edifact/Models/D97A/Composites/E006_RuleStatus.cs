using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E006")]
public class E006_RuleStatus : EdifactComponent
{
	[Position(1)]
	public string SpecialConditionsCoded { get; set; }

	[Position(2)]
	public string StatusIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E006_RuleStatus>(this);
		validator.Required(x=>x.SpecialConditionsCoded);
		validator.Required(x=>x.StatusIndicatorCoded);
		validator.Length(x => x.SpecialConditionsCoded, 1, 3);
		validator.Length(x => x.StatusIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
