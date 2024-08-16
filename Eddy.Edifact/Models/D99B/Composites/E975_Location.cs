using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E975")]
public class E975_Location : EdifactComponent
{
	[Position(1)]
	public string LocationNameCode { get; set; }

	[Position(2)]
	public string LocationName { get; set; }

	[Position(3)]
	public string CountryNameCode { get; set; }

	[Position(4)]
	public string LocationFunctionCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E975_Location>(this);
		validator.Length(x => x.LocationNameCode, 1, 25);
		validator.Length(x => x.LocationName, 1, 256);
		validator.Length(x => x.CountryNameCode, 1, 3);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		return validator.Results;
	}
}
