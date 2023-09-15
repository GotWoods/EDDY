using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("B1")]
public class B1_BeginningSegmentForBookingOrPickUpDelivery : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ReservationActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B1_BeginningSegmentForBookingOrPickUpDelivery>(this);
		validator.Required(x=>x.ShipmentIdentificationNumber);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ReservationActionCode, 1);
		return validator.Results;
	}
}
