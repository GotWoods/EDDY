using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("AT7")]
public class AT7_ShipmentStatusDetails : EdiX12Segment
{
	[Position(01)]
	public string ShipmentStatusIndicator { get; set; }

	[Position(02)]
	public string ShipmentStatusOrAppointmentReasonCode { get; set; }

	[Position(03)]
	public string ShipmentAppointmentStatusCode { get; set; }

	[Position(04)]
	public string ShipmentStatusOrAppointmentReasonCode2 { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT7_ShipmentStatusDetails>(this);
		validator.OnlyOneOf(x=>x.ShipmentStatusIndicator, x=>x.ShipmentAppointmentStatusCode);
		validator.ARequiresB(x=>x.ShipmentStatusOrAppointmentReasonCode, x=>x.ShipmentStatusIndicator);
		validator.ARequiresB(x=>x.ShipmentStatusOrAppointmentReasonCode2, x=>x.ShipmentAppointmentStatusCode);
		validator.ARequiresB(x=>x.Time, x=>x.Date);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.ShipmentStatusIndicator, 2);
		validator.Length(x => x.ShipmentStatusOrAppointmentReasonCode, 2);
		validator.Length(x => x.ShipmentAppointmentStatusCode, 2);
		validator.Length(x => x.ShipmentStatusOrAppointmentReasonCode2, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
