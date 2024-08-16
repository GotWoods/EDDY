using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E973")]
public class E973_DeliveringSystemDetails : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string PlaceLocationIdentification { get; set; }

	[Position(3)]
	public string PlaceLocation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E973_DeliveringSystemDetails>(this);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.PlaceLocation, 1, 70);
		return validator.Results;
	}
}
