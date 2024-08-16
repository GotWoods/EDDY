using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E006")]
public class E006_RuleStatus : EdifactComponent
{
	[Position(1)]
	public string SpecialConditionCode { get; set; }

	[Position(2)]
	public string ProcessingIndicatorDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E006_RuleStatus>(this);
		validator.Required(x=>x.SpecialConditionCode);
		validator.Length(x => x.SpecialConditionCode, 1, 3);
		validator.Length(x => x.ProcessingIndicatorDescriptionCode, 1, 3);
		return validator.Results;
	}
}
