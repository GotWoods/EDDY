using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("AT7")]
public class AT7_ShipmentStatusDetails : EdiX12Segment
{
	[Position(01)]
	public string ShipmentStatusCode { get; set; }

	[Position(02)]
	public string ShipmentStatusReasonCode { get; set; }

	[Position(03)]
	public string ShipmentAppointmentStatusCode { get; set; }

	[Position(04)]
	public string ShipmentAppointmentReasonCode { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public int? Century { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT7_ShipmentStatusDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ShipmentStatusCode, x=>x.ShipmentStatusReasonCode);
		validator.OnlyOneOf(x=>x.ShipmentStatusCode, x=>x.ShipmentAppointmentStatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ShipmentAppointmentStatusCode, x=>x.ShipmentAppointmentReasonCode);
		validator.ARequiresB(x=>x.Century, x=>x.Date);
		validator.ARequiresB(x=>x.Time, x=>x.Date);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.ShipmentStatusCode, 2);
		validator.Length(x => x.ShipmentStatusReasonCode, 2);
		validator.Length(x => x.ShipmentAppointmentStatusCode, 2);
		validator.Length(x => x.ShipmentAppointmentReasonCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
