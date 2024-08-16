using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("RCI")]
public class RCI_ReservationControlInformation : EdifactSegment
{
	[Position(1)]
	public E979_ReservationControlIdentification ReservationControlIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RCI_ReservationControlInformation>(this);
		return validator.Results;
	}
}
