using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("XPO")]
public class XPO_PreassignedPurchaseOrderNumbers : EdiX12Segment
{
    [Position(01)]
    public string PurchaseOrderNumber { get; set; }

    [Position(02)]
    public string PurchaseOrderNumber2 { get; set; }

    [Position(03)]
    public string IdentificationCodeQualifier { get; set; }

    [Position(04)]
    public string IdentificationCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<XPO_PreassignedPurchaseOrderNumbers>(this);
        validator.Required(x => x.PurchaseOrderNumber);
        validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCodeQualifier, x => x.IdentificationCode);
        validator.Length(x => x.PurchaseOrderNumber, 1, 22);
        validator.Length(x => x.PurchaseOrderNumber2, 1, 22);
        validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
        validator.Length(x => x.IdentificationCode, 2, 80);
        return validator.Results;
    }
}