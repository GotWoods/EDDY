using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("C814")]
public class C814_SafetySection : EdifactComponent
{
	[Position(1)]
	public string SafetySectionNumber { get; set; }

	[Position(2)]
	public string SafetySectionName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C814_SafetySection>(this);
		validator.Required(x=>x.SafetySectionNumber);
		validator.Length(x => x.SafetySectionNumber, 1, 2);
		validator.Length(x => x.SafetySectionName, 1, 70);
		return validator.Results;
	}
}
