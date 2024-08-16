using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E987")]
public class E987_ProductDateAndTime : EdifactComponent
{
	[Position(1)]
	public string DateValue { get; set; }

	[Position(2)]
	public string TimeValue { get; set; }

	[Position(3)]
	public string DateValue2 { get; set; }

	[Position(4)]
	public string TimeValue2 { get; set; }

	[Position(5)]
	public string DateVariationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E987_ProductDateAndTime>(this);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.TimeValue, 4);
		validator.Length(x => x.DateValue2, 1, 14);
		validator.Length(x => x.TimeValue2, 4);
		validator.Length(x => x.DateVariationNumber, 1, 5);
		return validator.Results;
	}
}
