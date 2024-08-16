using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S004")]
public class S004_DateAndTimeOfPreparation : EdifactComponent
{
	[Position(1)]
	public string Date { get; set; }

	[Position(2)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S004_DateAndTimeOfPreparation>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4);
		return validator.Results;
	}
}
