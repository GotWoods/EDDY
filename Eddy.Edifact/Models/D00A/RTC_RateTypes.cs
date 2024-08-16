using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("RTC")]
public class RTC_RateTypes : EdifactSegment
{
	[Position(1)]
	public string RateTypeIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTC_RateTypes>(this);
		validator.Required(x=>x.RateTypeIdentifier);
		validator.Length(x => x.RateTypeIdentifier, 1, 20);
		return validator.Results;
	}
}
