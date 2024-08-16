using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D02A.Composites;

[Segment("E961")]
public class E961_TransportDetails : EdifactComponent
{
	[Position(1)]
	public string TransportMeansDescriptionCode { get; set; }

	[Position(2)]
	public string JourneyStopsQuantity { get; set; }

	[Position(3)]
	public string JourneyLegDurationQuantity { get; set; }

	[Position(4)]
	public string Percentage { get; set; }

	[Position(5)]
	public string DaysOfWeekSetIdentifier { get; set; }

	[Position(6)]
	public string DateOrTimeOrPeriodText { get; set; }

	[Position(7)]
	public string TransportMeansChangeIndicatorCode { get; set; }

	[Position(8)]
	public string LocationNameCode { get; set; }

	[Position(9)]
	public string LocationNameCode2 { get; set; }

	[Position(10)]
	public string LocationNameCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E961_TransportDetails>(this);
		validator.Length(x => x.TransportMeansDescriptionCode, 1, 8);
		validator.Length(x => x.JourneyStopsQuantity, 1, 3);
		validator.Length(x => x.JourneyLegDurationQuantity, 1, 6);
		validator.Length(x => x.Percentage, 1, 10);
		validator.Length(x => x.DaysOfWeekSetIdentifier, 1, 7);
		validator.Length(x => x.DateOrTimeOrPeriodText, 1, 35);
		validator.Length(x => x.TransportMeansChangeIndicatorCode, 1);
		validator.Length(x => x.LocationNameCode, 1, 35);
		validator.Length(x => x.LocationNameCode2, 1, 35);
		validator.Length(x => x.LocationNameCode3, 1, 35);
		return validator.Results;
	}
}
