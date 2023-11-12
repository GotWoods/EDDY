using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("Y5")]
public class Y5_SpaceBookingCancellation : EdiX12Segment
{
	[Position(01)]
	public string BookingNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Y5_SpaceBookingCancellation>(this);
		validator.Required(x=>x.BookingNumber);
		validator.Length(x => x.BookingNumber, 1, 17);
		return validator.Results;
	}
}
