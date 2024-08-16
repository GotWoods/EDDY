using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ERC")]
public class ERC_ApplicationErrorInformation : EdifactSegment
{
	[Position(1)]
	public C901_ApplicationErrorDetail ApplicationErrorDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ERC_ApplicationErrorInformation>(this);
		validator.Required(x=>x.ApplicationErrorDetail);
		return validator.Results;
	}
}
