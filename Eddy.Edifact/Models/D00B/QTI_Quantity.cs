using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Models.D00B;

[Segment("QTI")]
public class QTI_Quantity : EdifactSegment
{
	[Position(1)]
	public E035_QuantityDetails QuantityDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<QTI_Quantity>(this);
		validator.Required(x=>x.QuantityDetails);
		return validator.Results;
	}
}
