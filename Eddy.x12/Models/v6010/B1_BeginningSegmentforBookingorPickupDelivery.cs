using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("B1")]
public class B1_BeginningSegmentForBookingOrPickupDelivery : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ReservationActionCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string ShipmentOrWorkAssignmentDeclineReasonCode { get; set; }

	[Position(07)]
	public string ShipmentMethodOfPayment { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B1_BeginningSegmentForBookingOrPickupDelivery>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReservationActionCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ShipmentOrWorkAssignmentDeclineReasonCode, 3);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		return validator.Results;
	}
}
