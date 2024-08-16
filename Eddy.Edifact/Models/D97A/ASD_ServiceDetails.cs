using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("ASD")]
public class ASD_ServiceDetails : EdifactSegment
{
	[Position(1)]
	public E959_ServiceDateTimeLocationInformation ServiceDateTimeLocationInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ASD_ServiceDetails>(this);
		validator.Required(x=>x.ServiceDateTimeLocationInformation);
		return validator.Results;
	}
}
