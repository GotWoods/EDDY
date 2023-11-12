using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("B1")]
public class B1_BeginningSegmentForBookingOrPickUpDelivery : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string BookingDate { get; set; }

	[Position(04)]
	public string ReservationActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B1_BeginningSegmentForBookingOrPickUpDelivery>(this);
		validator.Required(x=>x.ShipmentIdentificationNumber);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.BookingDate, 6);
		validator.Length(x => x.ReservationActionCode, 1);
		return validator.Results;
	}
}
