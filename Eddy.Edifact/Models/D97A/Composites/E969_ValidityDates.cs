using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E969")]
public class E969_ValidityDates : EdifactComponent
{
	[Position(1)]
	public string Date { get; set; }

	[Position(2)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E969_ValidityDates>(this);
		validator.Required(x=>x.Date);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.Date2, 1, 14);
		return validator.Results;
	}
}
