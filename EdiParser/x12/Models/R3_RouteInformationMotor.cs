using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("R3")]
public class R3_RouteInformationMotor : EdiX12Segment
{
    [Position(01)]
    public string StandardCarrierAlphaCode { get; set; }

    [Position(02)]
    public string RoutingSequenceCode { get; set; }

    [Position(03)]
    public string CityName { get; set; }

    [Position(04)]
    public string TransportationMethodTypeCode { get; set; }

    [Position(05)]
    public string StandardPointLocationCode { get; set; }

    [Position(06)]
    public string InvoiceNumber { get; set; }

    [Position(07)]
    public string Date { get; set; }

    [Position(08)]
    public string Amount { get; set; }

    [Position(09)]
    public string FreeFormDescription { get; set; }

    [Position(10)]
    public string ServiceLevelCode { get; set; }

    [Position(11)]
    public string ServiceLevelCode2 { get; set; }

    [Position(12)]
    public string ServiceLevelCode3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<R3_RouteInformationMotor>(this);
        validator.Required(x => x.StandardCarrierAlphaCode);
        validator.Required(x => x.RoutingSequenceCode);
        validator.ARequiresB(x => x.ServiceLevelCode2, x => x.ServiceLevelCode);
        validator.ARequiresB(x => x.ServiceLevelCode3, x => x.ServiceLevelCode2);
        validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
        validator.Length(x => x.RoutingSequenceCode, 1, 2);
        validator.Length(x => x.CityName, 2, 30);
        validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
        validator.Length(x => x.StandardPointLocationCode, 6, 9);
        validator.Length(x => x.InvoiceNumber, 1, 22);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.Amount, 1, 15);
        validator.Length(x => x.FreeFormDescription, 1, 45);
        validator.Length(x => x.ServiceLevelCode, 2);
        validator.Length(x => x.ServiceLevelCode2, 2);
        validator.Length(x => x.ServiceLevelCode3, 2);
        return validator.Results;
    }
}