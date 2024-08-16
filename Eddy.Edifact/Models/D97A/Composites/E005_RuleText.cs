using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E005")]
public class E005_RuleText : EdifactComponent
{
	[Position(1)]
	public string SpecialConditionsCoded { get; set; }

	[Position(2)]
	public string InformationTypeIdentification { get; set; }

	[Position(3)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E005_RuleText>(this);
		validator.Required(x=>x.SpecialConditionsCoded);
		validator.Length(x => x.SpecialConditionsCoded, 1, 3);
		validator.Length(x => x.InformationTypeIdentification, 1, 4);
		validator.Length(x => x.FreeText, 1, 70);
		return validator.Results;
	}
}
