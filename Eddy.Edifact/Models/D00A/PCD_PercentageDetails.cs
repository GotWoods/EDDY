using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PCD")]
public class PCD_PercentageDetails : EdifactSegment
{
	[Position(1)]
	public C501_PercentageDetails PercentageDetails { get; set; }

	[Position(2)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCD_PercentageDetails>(this);
		validator.Required(x=>x.PercentageDetails);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
