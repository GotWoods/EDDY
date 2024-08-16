using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("PRI")]
public class PRI_PriceDetails : EdifactSegment
{
	[Position(1)]
	public C509_PriceInformation PriceInformation { get; set; }

	[Position(2)]
	public string SubLinePriceChangeCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRI_PriceDetails>(this);
		validator.Length(x => x.SubLinePriceChangeCoded, 1, 3);
		return validator.Results;
	}
}
