using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("PCD")]
public class PCD_PercentageDetails : EdifactSegment
{
	[Position(1)]
	public C501_PercentageDetails PercentageDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCD_PercentageDetails>(this);
		validator.Required(x=>x.PercentageDetails);
		return validator.Results;
	}
}
