using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Models.D00B;

[Segment("TIZ")]
public class TIZ_TimeZoneInformation : EdifactSegment
{
	[Position(1)]
	public E034_TimeZone TimeZone { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TIZ_TimeZoneInformation>(this);
		validator.Required(x=>x.TimeZone);
		return validator.Results;
	}
}
