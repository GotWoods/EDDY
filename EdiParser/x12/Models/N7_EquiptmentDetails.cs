using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("N7")]
public class N7_EquipmentDetails : EdiX12Segment
{
    [Position(01)]
    public string EquipmentInitial { get; set; }

    [Position(02)]
    public string EquipmentNumber { get; set; }

    [Position(03)]
    public decimal? Weight { get; set; }

    [Position(04)]
    public string WeightQualifier { get; set; }

    [Position(05)]
    public string TareWeight { get; set; }

    [Position(06)]
    public string WeightAllowance { get; set; }

    [Position(07)]
    public string Dunnage { get; set; }

    [Position(08)]
    public string Volume { get; set; }

    [Position(09)]
    public string VolumeUnitQualifier { get; set; }

    [Position(10)]
    public string OwnershipCode { get; set; }

    [Position(11)]
    public string EquipmentDescriptionCode { get; set; }

    [Position(12)]
    public string StandardCarrierAlphaCode { get; set; }

    [Position(13)]
    public string TemperatureControl { get; set; }

    [Position(14)]
    public string Position { get; set; }

    [Position(15)]
    public string EquipmentLength { get; set; }

    [Position(16)]
    public string TareQualifierCode { get; set; }

    [Position(17)]
    public string WeightUnitCode { get; set; }

    [Position(18)]
    public string EquipmentNumberCheckDigit { get; set; }

    [Position(19)]
    public string TypeOfServiceCode { get; set; }

    [Position(20)]
    public decimal? Height { get; set; }

    [Position(21)]
    public decimal? Width { get; set; }

    [Position(22)]
    public string EquipmentTypeCode { get; set; }

    [Position(23)]
    public string StandardCarrierAlphaCode2 { get; set; }

    [Position(24)]
    public string CarTypeCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<N7_EquipmentDetails>(this);
        validator.Required(x => x.EquipmentNumber);
        validator.IfOneIsFilled_AllAreRequired(x => x.Weight, x => x.WeightQualifier);
        validator.IfOneIsFilled_AllAreRequired(x => x.TareWeight, x => x.TareQualifierCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.Volume, x => x.VolumeUnitQualifier);
        validator.Length(x => x.EquipmentInitial, 1, 4);
        validator.Length(x => x.EquipmentNumber, 1, 15);
        validator.Length(x => x.Weight, 1, 10);
        validator.Length(x => x.WeightQualifier, 1, 2);
        validator.Length(x => x.TareWeight, 3, 8);
        validator.Length(x => x.WeightAllowance, 2, 6);
        validator.Length(x => x.Dunnage, 1, 6);
        validator.Length(x => x.Volume, 1, 8);
        validator.Length(x => x.VolumeUnitQualifier, 1);
        validator.Length(x => x.OwnershipCode, 1);
        validator.Length(x => x.EquipmentDescriptionCode, 2);
        validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
        validator.Length(x => x.TemperatureControl, 3, 6);
        validator.Length(x => x.Position, 1, 3);
        validator.Length(x => x.EquipmentLength, 4, 5);
        validator.Length(x => x.TareQualifierCode, 1);
        validator.Length(x => x.WeightUnitCode, 1);
        validator.Length(x => x.EquipmentNumberCheckDigit, 1);
        validator.Length(x => x.TypeOfServiceCode, 2);
        validator.Length(x => x.Height, 1, 8);
        validator.Length(x => x.Width, 1, 8);
        validator.Length(x => x.EquipmentTypeCode, 4);
        validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
        validator.Length(x => x.CarTypeCode, 1, 4);
        return validator.Results;
    }
}