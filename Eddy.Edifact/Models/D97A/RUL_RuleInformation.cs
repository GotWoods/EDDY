using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("RUL")]
public class RUL_RuleInformation : EdifactSegment
{
	[Position(1)]
	public E004_RuleDetails RuleDetails { get; set; }

	[Position(2)]
	public E005_RuleText RuleText { get; set; }

	[Position(3)]
	public E006_RuleStatus RuleStatus { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RUL_RuleInformation>(this);
		return validator.Results;
	}
}
