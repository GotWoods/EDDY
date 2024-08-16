using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("RTC")]
public class RTC_RateTypes : EdifactSegment
{
	[Position(1)]
	public string RateTypeIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTC_RateTypes>(this);
		validator.Required(x=>x.RateTypeIdentification);
		validator.Length(x => x.RateTypeIdentification, 1, 20);
		return validator.Results;
	}
}
