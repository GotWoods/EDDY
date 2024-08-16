using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E993")]
public class E993_TourDetails : EdifactComponent
{
	[Position(1)]
	public string ProductIdentifier { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	[Position(3)]
	public string LengthMeasure { get; set; }

	[Position(4)]
	public string JourneyStopsQuantity { get; set; }

	[Position(5)]
	public string DaysOfWeekSetIdentifier { get; set; }

	[Position(6)]
	public string UnitsQuantity { get; set; }

	[Position(7)]
	public string Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E993_TourDetails>(this);
		validator.Length(x => x.ProductIdentifier, 1, 35);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.LengthMeasure, 1, 15);
		validator.Length(x => x.JourneyStopsQuantity, 1, 3);
		validator.Length(x => x.DaysOfWeekSetIdentifier, 1, 7);
		validator.Length(x => x.UnitsQuantity, 1, 15);
		validator.Length(x => x.Quantity, 1, 35);
		return validator.Results;
	}
}
