using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E034")]
public class E034_TimeZone : EdifactComponent
{
	[Position(1)]
	public string TimeZoneIdentifier { get; set; }

	[Position(2)]
	public string TimeZoneDifferenceQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E034_TimeZone>(this);
		validator.Required(x=>x.TimeZoneIdentifier);
		validator.Length(x => x.TimeZoneIdentifier, 1, 3);
		validator.Length(x => x.TimeZoneDifferenceQuantity, 1, 4);
		return validator.Results;
	}
}
