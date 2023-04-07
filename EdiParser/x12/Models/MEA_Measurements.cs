using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("MEA")]
public class MEA_Measurements : EdiX12Segment
{
    [Position(01)]
    public string MeasurementReferenceIDCode { get; set; }

    [Position(02)]
    public string MeasurementQualifier { get; set; }

    [Position(03)]
    public decimal? MeasurementValue { get; set; }

    //TODO: C001_CompositeUnitOfMeasure
    [Position(04)]
    public string CompositeUnitOfMeasure { get; set; }

    [Position(05)]
    public decimal? RangeMinimum { get; set; }

    [Position(06)]
    public decimal? RangeMaximum { get; set; }

    [Position(07)]
    public string MeasurementSignificanceCode { get; set; }

    [Position(08)]
    public string MeasurementAttributeCode { get; set; }

    [Position(09)]
    public string SurfaceLayerPositionCode { get; set; }

    [Position(10)]
    public string MeasurementMethodOrDeviceCode { get; set; }

    [Position(11)]
    public string CodeListQualifierCode { get; set; }

    [Position(12)]
    public string IndustryCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<MEA_Measurements>(this);
        validator.IfOneIsFilledThenAtLeastOne(x => x.RangeMinimum, x => x.CompositeUnitOfMeasure, x => x.IndustryCode);
        validator.IfOneIsFilledThenAtLeastOne(x => x.RangeMaximum, x => x.CompositeUnitOfMeasure, x => x.IndustryCode);
        validator.IfOneIsFilledThenAtLeastOne(x => x.MeasurementSignificanceCode, x => x.MeasurementValue, x => x.RangeMinimum, x => x.RangeMaximum);
        validator.OnlyOneOf(x => x.MeasurementAttributeCode, x => x.MeasurementValue);
        validator.IfOneIsFilled_AllAreRequired(x => x.CodeListQualifierCode, x => x.IndustryCode);
        validator.Length(x => x.MeasurementReferenceIDCode, 2);
        validator.Length(x => x.MeasurementQualifier, 1, 3);
        validator.Length(x => x.MeasurementValue, 1, 20);
        validator.Length(x => x.RangeMinimum, 1, 20);
        validator.Length(x => x.RangeMaximum, 1, 20);
        validator.Length(x => x.MeasurementSignificanceCode, 2);
        validator.Length(x => x.MeasurementAttributeCode, 2);
        validator.Length(x => x.SurfaceLayerPositionCode, 2);
        validator.Length(x => x.MeasurementMethodOrDeviceCode, 2, 4);
        validator.Length(x => x.CodeListQualifierCode, 1, 3);
        validator.Length(x => x.IndustryCode, 1, 30);
        return validator.Results;
    }
}