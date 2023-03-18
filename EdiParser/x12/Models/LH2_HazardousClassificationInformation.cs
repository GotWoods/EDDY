using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("LH2")]
public class LH2_HazardousClassificationInformation : EdiX12Segment
{
    [Position(01)]
    public string HazardousClassificationCode { get; set; }

    [Position(02)]
    public string HazardousClassQualifier { get; set; }

    [Position(03)]
    public string HazardousPlacardNotationCode { get; set; }

    [Position(04)]
    public string HazardousEndorsementCode { get; set; }

    [Position(05)]
    public string ReportableQuantityCode { get; set; }

    [Position(06)]
    public string UnitOrBasisForMeasurementCode { get; set; }

    [Position(07)]
    public decimal? Temperature { get; set; }

    [Position(08)]
    public string UnitOrBasisForMeasurementCode2 { get; set; }

    [Position(09)]
    public decimal? Temperature2 { get; set; }

    [Position(10)]
    public string UnitOrBasisForMeasurementCode3 { get; set; }

    [Position(11)]
    public decimal? Temperature3 { get; set; }

    [Position(12)]
    public string WeightUnitCode { get; set; }

    [Position(13)]
    public int? NetExplosiveQuantity { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<LH2_HazardousClassificationInformation>(this);
        validator.IfOneIsFilled_AllAreRequired(x => x.UnitOrBasisForMeasurementCode, x => x.Temperature);
        validator.IfOneIsFilled_AllAreRequired(x => x.UnitOrBasisForMeasurementCode2, x => x.Temperature2);
        validator.IfOneIsFilled_AllAreRequired(x => x.UnitOrBasisForMeasurementCode3, x => x.Temperature3);
        validator.IfOneIsFilled_AllAreRequired(x => x.WeightUnitCode, x => x.NetExplosiveQuantity);
        validator.Length(x => x.HazardousClassificationCode, 1, 30);
        validator.Length(x => x.HazardousClassQualifier, 1);
        validator.Length(x => x.HazardousPlacardNotationCode, 14, 40);
        validator.Length(x => x.HazardousEndorsementCode, 4, 25);
        validator.Length(x => x.ReportableQuantityCode, 2);
        validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
        validator.Length(x => x.Temperature, 1, 4);
        validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
        validator.Length(x => x.Temperature2, 1, 4);
        validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
        validator.Length(x => x.Temperature3, 1, 4);
        validator.Length(x => x.WeightUnitCode, 1);
        validator.Length(x => x.NetExplosiveQuantity, 1, 10);
        return validator.Results;
    }
}