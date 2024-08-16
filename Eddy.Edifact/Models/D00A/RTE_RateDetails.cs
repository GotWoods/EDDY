using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("RTE")]
public class RTE_RateDetails : EdifactSegment
{
	[Position(1)]
	public C128_RateDetails RateDetails { get; set; }

	[Position(2)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTE_RateDetails>(this);
		validator.Required(x=>x.RateDetails);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
