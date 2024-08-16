using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E999")]
public class E999_ConnectionDetails : EdifactComponent
{
	[Position(1)]
	public string PlaceLocationIdentification { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	[Position(3)]
	public string Time { get; set; }

	[Position(4)]
	public string Time2 { get; set; }

	[Position(5)]
	public string PlaceLocation { get; set; }

	[Position(6)]
	public string PlaceLocationQualifier { get; set; }

	[Position(7)]
	public string CountryCoded { get; set; }

	[Position(8)]
	public string SequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E999_ConnectionDetails>(this);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.PlaceLocation, 1, 70);
		validator.Length(x => x.PlaceLocationQualifier, 1, 3);
		validator.Length(x => x.CountryCoded, 1, 3);
		validator.Length(x => x.SequenceNumber, 1, 10);
		return validator.Results;
	}
}
