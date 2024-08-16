using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E005")]
public class E005_RuleText : EdifactComponent
{
	[Position(1)]
	public string SpecialConditionCode { get; set; }

	[Position(2)]
	public string InformationTypeCode { get; set; }

	[Position(3)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E005_RuleText>(this);
		validator.Required(x=>x.SpecialConditionCode);
		validator.Length(x => x.SpecialConditionCode, 1, 3);
		validator.Length(x => x.InformationTypeCode, 1, 4);
		validator.Length(x => x.FreeText, 1, 512);
		return validator.Results;
	}
}
