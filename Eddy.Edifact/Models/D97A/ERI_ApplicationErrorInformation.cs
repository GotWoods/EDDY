using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("ERI")]
public class ERI_ApplicationErrorInformation : EdifactSegment
{
	[Position(1)]
	public E901_ApplicationErrorDetails ApplicationErrorDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ERI_ApplicationErrorInformation>(this);
		validator.Required(x=>x.ApplicationErrorDetails);
		return validator.Results;
	}
}
