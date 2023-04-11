using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("SPO")]
public class SPO_ShipmentPurchaseOrderDetail : EdiX12Segment
{
    [Position(01)]
    public string PurchaseOrderNumber { get; set; }

    [Position(02)]
    public string ReferenceIdentification { get; set; }

    [Position(03)]
    public string UnitOrBasisForMeasurementCode { get; set; }

    [Position(04)]
    public decimal? Quantity { get; set; }

    [Position(05)]
    public string WeightUnitCode { get; set; }

    [Position(06)]
    public decimal? Weight { get; set; }

    [Position(07)]
    public string ApplicationErrorConditionCode { get; set; }

    [Position(08)]
    public string ReferenceIdentification2 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<SPO_ShipmentPurchaseOrderDetail>(this);
        validator.Required(x => x.PurchaseOrderNumber);
        validator.IfOneIsFilled_AllAreRequired(x => x.UnitOrBasisForMeasurementCode, x => x.Quantity);
        validator.IfOneIsFilled_AllAreRequired(x => x.WeightUnitCode, x => x.Weight);
        validator.Length(x => x.PurchaseOrderNumber, 1, 22);
        validator.Length(x => x.ReferenceIdentification, 1, 30);
        validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.WeightUnitCode, 1);
        validator.Length(x => x.Weight, 1, 10);
        validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
        validator.Length(x => x.ReferenceIdentification2, 1, 30);
        return validator.Results;
    }
}