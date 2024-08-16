using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E993")]
public class E993_TourDetails : EdifactComponent
{
	[Position(1)]
	public string ProductIdentification { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	[Position(3)]
	public string LengthDimension { get; set; }

	[Position(4)]
	public string NumberOfStops { get; set; }

	[Position(5)]
	public string DaysOfOperation { get; set; }

	[Position(6)]
	public string NumberOfUnits { get; set; }

	[Position(7)]
	public string Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E993_TourDetails>(this);
		validator.Length(x => x.ProductIdentification, 1, 35);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.LengthDimension, 1, 15);
		validator.Length(x => x.NumberOfStops, 1, 3);
		validator.Length(x => x.DaysOfOperation, 1, 7);
		validator.Length(x => x.NumberOfUnits, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
