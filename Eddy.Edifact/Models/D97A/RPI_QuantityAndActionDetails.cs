using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("RPI")]
public class RPI_QuantityAndActionDetails : EdifactSegment
{
	[Position(1)]
	public E958_QuantityAndActionDetails QuantityAndActionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RPI_QuantityAndActionDetails>(this);
		validator.Required(x=>x.QuantityAndActionDetails);
		return validator.Results;
	}
}
