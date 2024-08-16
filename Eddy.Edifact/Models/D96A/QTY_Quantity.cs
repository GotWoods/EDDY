using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("QTY")]
public class QTY_Quantity : EdifactSegment
{
	[Position(1)]
	public C186_QuantityDetails QuantityDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<QTY_Quantity>(this);
		validator.Required(x=>x.QuantityDetails);
		return validator.Results;
	}
}
