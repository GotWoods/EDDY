using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("ATI")]
public class ATI_TourInformation : EdifactSegment
{
	[Position(1)]
	public E993_TourDetails TourDetails { get; set; }

	[Position(2)]
	public E994_StopoverInformation StopoverInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATI_TourInformation>(this);
		return validator.Results;
	}
}
