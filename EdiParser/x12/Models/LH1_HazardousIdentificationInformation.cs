using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("LH1")]
public class LH1_HazardousIdentificationInformation : EdiX12Segment
{
    [Position(01)]
    public string UnitOrBasisForMeasurementCode { get; set; }

    [Position(02)]
    public int? LadingQuantity { get; set; }

    [Position(03)]
    public string UNNAIdentificationCode { get; set; }

    [Position(04)]
    public string HazardousMaterialsPage { get; set; }

    [Position(05)]
    public string CommodityCode { get; set; }

    [Position(06)]
    public string UnitOrBasisForMeasurementCode2 { get; set; }

    [Position(07)]
    public decimal? Quantity { get; set; }

    [Position(08)]
    public string CompartmentIDCode { get; set; }

    [Position(09)]
    public string ResidueIndicatorCode { get; set; }

    [Position(10)]
    public string PackingGroupCode { get; set; }

    [Position(11)]
    public string InterimHazardousMaterialRegulatoryNumber { get; set; }

    [Position(12)]
    public string IndustryCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<LH1_HazardousIdentificationInformation>(this);
        validator.Required(x => x.UnitOrBasisForMeasurementCode);
        validator.Required(x => x.LadingQuantity);
        validator.IfOneIsFilled_AllAreRequired(x => x.UnitOrBasisForMeasurementCode2, x => x.Quantity);
        validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
        validator.Length(x => x.LadingQuantity, 1, 7);
        validator.Length(x => x.UNNAIdentificationCode, 6);
        validator.Length(x => x.HazardousMaterialsPage, 1, 6);
        validator.Length(x => x.CommodityCode, 1, 30);
        validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.CompartmentIDCode, 1);
        validator.Length(x => x.ResidueIndicatorCode, 1);
        validator.Length(x => x.PackingGroupCode, 1, 3);
        validator.Length(x => x.InterimHazardousMaterialRegulatoryNumber, 1, 5);
        validator.Length(x => x.IndustryCode, 1, 30);
        return validator.Results;
    }
}