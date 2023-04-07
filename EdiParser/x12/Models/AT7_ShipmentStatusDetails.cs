using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("AT7")]
public class AT7_ShipmentStatusDetails : EdiX12Segment
{
    [Position(1)]
    public string ShipmentStatusIndicatorCode { get; set; }

    [Position(2)]
    public string ShipmentStatusOrAppointmentReasonCode { get; set; }

    [Position(3)]
    public string ShipmentAppointmentStatusCode { get; set; }

    [Position(4)]
    public string ShipmentStatusOrAppointmentReasonCode2 { get; set; }

    [Position(5)]
    public string Date { get; set; }

    [Position(6)]
    public string Time { get; set; }

    [Position(7)]
    public string TimeCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AT7_ShipmentStatusDetails>(this);
        
        validator.Length(x => x.ShipmentStatusIndicatorCode, 2);
        validator.Length(x => x.ShipmentAppointmentStatusCode, 2);
        validator.Length(x => x.ShipmentStatusOrAppointmentReasonCode, 2);
        validator.Length(x => x.ShipmentStatusOrAppointmentReasonCode2, 2);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.Time, 4, 8);
        validator.Length(x => x.TimeCode, 2);

        validator.ARequiresB(x => x.ShipmentStatusOrAppointmentReasonCode, x => x.ShipmentStatusIndicatorCode);
        validator.ARequiresB(x => x.ShipmentStatusOrAppointmentReasonCode2, x => x.ShipmentAppointmentStatusCode);
        validator.ARequiresB(x => x.Time, x => x.Date);
        validator.ARequiresB(x => x.TimeCode, x => x.Time);

        validator.OnlyOneOf(x => x.ShipmentStatusIndicatorCode, x => x.ShipmentAppointmentStatusCode);

        validator.VerifyDateFormat(x=>x.Date);
        validator.VerifyTimeFormat(x=>x.Time);

        return validator.Results;
    }


}