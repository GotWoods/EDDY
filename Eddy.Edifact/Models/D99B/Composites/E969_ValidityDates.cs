using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E969")]
public class E969_ValidityDates : EdifactComponent
{
	[Position(1)]
	public string DateValue { get; set; }

	[Position(2)]
	public string DateValue2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E969_ValidityDates>(this);
		validator.Required(x=>x.DateValue);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.DateValue2, 1, 14);
		return validator.Results;
	}
}
