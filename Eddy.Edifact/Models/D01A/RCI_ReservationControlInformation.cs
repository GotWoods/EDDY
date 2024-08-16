using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01A.Composites;

namespace Eddy.Edifact.Models.D01A;

[Segment("RCI")]
public class RCI_ReservationControlInformation : EdifactSegment
{
	[Position(1)]
	public E979_ReservationControlInformation ReservationControlInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RCI_ReservationControlInformation>(this);
		return validator.Results;
	}
}
