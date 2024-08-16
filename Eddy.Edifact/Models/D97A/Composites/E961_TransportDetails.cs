using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E961")]
public class E961_TransportDetails : EdifactComponent
{
	[Position(1)]
	public string TypeOfMeansOfTransportIdentification { get; set; }

	[Position(2)]
	public string NumberOfStops { get; set; }

	[Position(3)]
	public string LegDuration { get; set; }

	[Position(4)]
	public string Percentage { get; set; }

	[Position(5)]
	public string DaysOfOperation { get; set; }

	[Position(6)]
	public string DateTimePeriod { get; set; }

	[Position(7)]
	public string ComplexingTransportIndicator { get; set; }

	[Position(8)]
	public string PlaceLocationIdentification { get; set; }

	[Position(9)]
	public string PlaceLocationIdentification2 { get; set; }

	[Position(10)]
	public string PlaceLocationIdentification3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E961_TransportDetails>(this);
		validator.Length(x => x.TypeOfMeansOfTransportIdentification, 1, 8);
		validator.Length(x => x.NumberOfStops, 1, 3);
		validator.Length(x => x.LegDuration, 1, 6);
		validator.Length(x => x.Percentage, 1, 10);
		validator.Length(x => x.DaysOfOperation, 1, 7);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ComplexingTransportIndicator, 1);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.PlaceLocationIdentification2, 1, 25);
		validator.Length(x => x.PlaceLocationIdentification3, 1, 25);
		return validator.Results;
	}
}
