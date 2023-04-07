using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("FOB")]
public class FOB_RelatedInstructions : EdiX12Segment 
{
    [Position(01)]
    public string ShipmentMethodOfPaymentCode { get; set; }

    [Position(02)]
    public string LocationQualifier { get; set; }

    [Position(03)]
    public string Description { get; set; }

    [Position(04)]
    public string TransportationTermsQualifierCode { get; set; }

    [Position(05)]
    public string TransportationTermsCode { get; set; }

    [Position(06)]
    public string LocationQualifier2 { get; set; }

    [Position(07)]
    public string Description2 { get; set; }

    [Position(08)]
    public string RiskOfLossCode { get; set; }

    [Position(09)]
    public string Description3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<FOB_RelatedInstructions>(this);
        validator.Required(x => x.ShipmentMethodOfPaymentCode);
        validator.ARequiresB(x => x.Description, x => x.LocationQualifier);
        validator.ARequiresB(x => x.TransportationTermsQualifierCode, x => x.TransportationTermsCode);
        validator.ARequiresB(x => x.Description2, x => x.LocationQualifier2);
        validator.ARequiresB(x => x.RiskOfLossCode, x => x.Description3);
        validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
        validator.Length(x => x.LocationQualifier, 1, 2);
        validator.Length(x => x.Description, 1, 80);
        validator.Length(x => x.TransportationTermsQualifierCode, 2);
        validator.Length(x => x.TransportationTermsCode, 3);
        validator.Length(x => x.LocationQualifier2, 1, 2);
        validator.Length(x => x.Description2, 1, 80);
        validator.Length(x => x.RiskOfLossCode, 2);
        validator.Length(x => x.Description3, 1, 80);
        return validator.Results;
    }
}