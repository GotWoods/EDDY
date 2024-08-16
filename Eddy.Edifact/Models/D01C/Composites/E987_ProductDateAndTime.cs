using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E987")]
public class E987_ProductDateAndTime : EdifactComponent
{
	[Position(1)]
	public string Date { get; set; }

	[Position(2)]
	public string Time { get; set; }

	[Position(3)]
	public string Date2 { get; set; }

	[Position(4)]
	public string Time2 { get; set; }

	[Position(5)]
	public string DateVariationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E987_ProductDateAndTime>(this);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Date2, 1, 14);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.DateVariationNumber, 1, 5);
		return validator.Results;
	}
}
