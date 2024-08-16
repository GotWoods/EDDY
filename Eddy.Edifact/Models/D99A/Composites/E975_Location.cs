using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E975")]
public class E975_Location : EdifactComponent
{
	[Position(1)]
	public string PlaceLocationIdentification { get; set; }

	[Position(2)]
	public string PlaceLocation { get; set; }

	[Position(3)]
	public string CountryCoded { get; set; }

	[Position(4)]
	public string PlaceLocationQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E975_Location>(this);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.PlaceLocation, 1, 70);
		validator.Length(x => x.CountryCoded, 1, 3);
		validator.Length(x => x.PlaceLocationQualifier, 1, 3);
		return validator.Results;
	}
}
