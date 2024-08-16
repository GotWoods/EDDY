using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("E975")]
public class E975_Location : EdifactComponent
{
	[Position(1)]
	public string LocationIdentifier { get; set; }

	[Position(2)]
	public string LocationName { get; set; }

	[Position(3)]
	public string CountryIdentifier { get; set; }

	[Position(4)]
	public string LocationFunctionCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E975_Location>(this);
		validator.Length(x => x.LocationIdentifier, 1, 35);
		validator.Length(x => x.LocationName, 1, 256);
		validator.Length(x => x.CountryIdentifier, 1, 3);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		return validator.Results;
	}
}
