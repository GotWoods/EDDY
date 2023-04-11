using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C073")]
public class C073_CompositeGrapeVarietalSequence : EdiX12Component
{
    [Position(00)]
    public string AssignedIdentification { get; set; }

    [Position(01)]
    public string GrapeVarietalCode { get; set; }

    [Position(02)]
    public decimal? MeasurementValue { get; set; }

    [Position(03)]
    public string AssignedIdentification2 { get; set; }

    [Position(04)]
    public string GrapeVarietalCode2 { get; set; }

    [Position(05)]
    public decimal? MeasurementValue2 { get; set; }

    [Position(06)]
    public string AssignedIdentification3 { get; set; }

    [Position(07)]
    public string GrapeVarietalCode3 { get; set; }

    [Position(08)]
    public decimal? MeasurementValue3 { get; set; }

    [Position(09)]
    public string AssignedIdentification4 { get; set; }

    [Position(10)]
    public string GrapeVarietalCode4 { get; set; }

    [Position(11)]
    public decimal? MeasurementValue4 { get; set; }

    [Position(12)]
    public string AssignedIdentification5 { get; set; }

    [Position(13)]
    public string GrapeVarietalCode5 { get; set; }

    [Position(14)]
    public decimal? MeasurementValue5 { get; set; }

    [Position(15)]
    public string AssignedIdentification6 { get; set; }

    [Position(16)]
    public string GrapeVarietalCode6 { get; set; }

    [Position(17)]
    public decimal? MeasurementValue6 { get; set; }

    [Position(18)]
    public string AssignedIdentification7 { get; set; }

    [Position(19)]
    public string GrapeVarietalCode7 { get; set; }

    [Position(20)]
    public decimal? MeasurementValue7 { get; set; }

    [Position(21)]
    public string AssignedIdentification8 { get; set; }

    [Position(22)]
    public string GrapeVarietalCode8 { get; set; }

    [Position(23)]
    public decimal? MeasurementValue8 { get; set; }

    [Position(24)]
    public string AssignedIdentification9 { get; set; }

    [Position(25)]
    public string GrapeVarietalCode9 { get; set; }

    [Position(26)]
    public decimal? MeasurementValue9 { get; set; }

    [Position(27)]
    public string AssignedIdentification10 { get; set; }

    [Position(28)]
    public string GrapeVarietalCode10 { get; set; }

    [Position(29)]
    public decimal? MeasurementValue10 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C073_CompositeGrapeVarietalSequence>(this);
        validator.Required(x => x.AssignedIdentification);
        validator.Length(x => x.AssignedIdentification, 1, 20);
        validator.Length(x => x.GrapeVarietalCode, 2, 3);
        validator.Length(x => x.MeasurementValue, 1, 20);
        validator.Length(x => x.AssignedIdentification2, 1, 20);
        validator.Length(x => x.GrapeVarietalCode2, 2, 3);
        validator.Length(x => x.MeasurementValue2, 1, 20);
        validator.Length(x => x.AssignedIdentification3, 1, 20);
        validator.Length(x => x.GrapeVarietalCode3, 2, 3);
        validator.Length(x => x.MeasurementValue3, 1, 20);
        validator.Length(x => x.AssignedIdentification4, 1, 20);
        validator.Length(x => x.GrapeVarietalCode4, 2, 3);
        validator.Length(x => x.MeasurementValue4, 1, 20);
        validator.Length(x => x.AssignedIdentification5, 1, 20);
        validator.Length(x => x.GrapeVarietalCode5, 2, 3);
        validator.Length(x => x.MeasurementValue5, 1, 20);
        validator.Length(x => x.AssignedIdentification6, 1, 20);
        validator.Length(x => x.GrapeVarietalCode6, 2, 3);
        validator.Length(x => x.MeasurementValue6, 1, 20);
        validator.Length(x => x.AssignedIdentification7, 1, 20);
        validator.Length(x => x.GrapeVarietalCode7, 2, 3);
        validator.Length(x => x.MeasurementValue7, 1, 20);
        validator.Length(x => x.AssignedIdentification8, 1, 20);
        validator.Length(x => x.GrapeVarietalCode8, 2, 3);
        validator.Length(x => x.MeasurementValue8, 1, 20);
        validator.Length(x => x.AssignedIdentification9, 1, 20);
        validator.Length(x => x.GrapeVarietalCode9, 2, 3);
        validator.Length(x => x.MeasurementValue9, 1, 20);
        validator.Length(x => x.AssignedIdentification10, 1, 20);
        validator.Length(x => x.GrapeVarietalCode10, 2, 3);
        validator.Length(x => x.MeasurementValue10, 1, 20);
        return validator.Results;
    }
}