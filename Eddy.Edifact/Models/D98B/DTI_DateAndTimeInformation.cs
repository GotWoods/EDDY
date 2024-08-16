using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("DTI")]
public class DTI_DateAndTimeInformation : EdifactSegment
{
	[Position(1)]
	public E013_DateAndTimeInformation DateAndTimeInformation { get; set; }

	[Position(2)]
	public E014_TimeReferenceDetails TimeReferenceDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DTI_DateAndTimeInformation>(this);
		validator.Required(x=>x.DateAndTimeInformation);
		return validator.Results;
	}
}
