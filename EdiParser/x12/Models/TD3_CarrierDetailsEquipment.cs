using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("TD3")]
public class TD3_CarrierDetailsEquipment : EdiX12Segment
{
    [Position(01)]
    public string EquipmentDescriptionCode { get; set; }

    [Position(02)]
    public string EquipmentInitial { get; set; }

    [Position(03)]
    public string EquipmentNumber { get; set; }

    [Position(04)]
    public string WeightQualifier { get; set; }

    [Position(05)]
    public decimal? Weight { get; set; }

    [Position(06)]
    public string UnitOrBasisForMeasurementCode { get; set; }

    [Position(07)]
    public string OwnershipCode { get; set; }

    [Position(08)]
    public string SealStatusCode { get; set; }

    [Position(09)]
    public string SealNumber { get; set; }

    [Position(10)]
    public string EquipmentTypeCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<TD3_CarrierDetailsEquipment>(this);
        validator.OnlyOneOf(x => x.EquipmentDescriptionCode, x => x.EquipmentTypeCode);
        validator.ARequiresB(x => x.EquipmentInitial, x => x.EquipmentNumber);
        validator.ARequiresB(x => x.WeightQualifier, x => x.Weight);
        validator.IfOneIsFilled_AllAreRequired(x => x.Weight, x => x.UnitOrBasisForMeasurementCode);
        validator.Length(x => x.EquipmentDescriptionCode, 2);
        validator.Length(x => x.EquipmentInitial, 1, 4);
        validator.Length(x => x.EquipmentNumber, 1, 15);
        validator.Length(x => x.WeightQualifier, 1, 2);
        validator.Length(x => x.Weight, 1, 10);
        validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
        validator.Length(x => x.OwnershipCode, 1);
        validator.Length(x => x.SealStatusCode, 2);
        validator.Length(x => x.SealNumber, 1, 15);
        validator.Length(x => x.EquipmentTypeCode, 4);
        return validator.Results;
    }
}