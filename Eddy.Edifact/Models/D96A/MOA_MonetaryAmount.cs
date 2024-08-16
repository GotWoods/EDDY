using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("MOA")]
public class MOA_MonetaryAmount : EdifactSegment
{
	[Position(1)]
	public C516_MonetaryAmount MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MOA_MonetaryAmount>(this);
		validator.Required(x=>x.MonetaryAmount);
		return validator.Results;
	}
}
