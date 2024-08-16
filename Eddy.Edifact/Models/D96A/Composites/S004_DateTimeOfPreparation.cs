using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S004")]
public class S004_DateTimeOfPreparation : EdifactComponent
{
	[Position(1)]
	public string DateOfPreparation { get; set; }

	[Position(2)]
	public string TimeOfPreparation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S004_DateTimeOfPreparation>(this);
		validator.Required(x=>x.DateOfPreparation);
		validator.Required(x=>x.TimeOfPreparation);
		validator.Length(x => x.DateOfPreparation, 6);
		validator.Length(x => x.TimeOfPreparation, 4);
		return validator.Results;
	}
}
