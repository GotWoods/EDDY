using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("E994")]
public class E994_StopoverInformation : EdifactComponent
{
	[Position(1)]
	public string LocationIdentifier { get; set; }

	[Position(2)]
	public string UnitsQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E994_StopoverInformation>(this);
		validator.Length(x => x.LocationIdentifier, 1, 35);
		validator.Length(x => x.UnitsQuantity, 1, 15);
		return validator.Results;
	}
}