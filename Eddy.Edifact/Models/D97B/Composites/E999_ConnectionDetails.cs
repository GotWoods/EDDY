using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97B.Composites;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E999_ConnectionDetails>(this);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		return validator.Results;
	}
}
