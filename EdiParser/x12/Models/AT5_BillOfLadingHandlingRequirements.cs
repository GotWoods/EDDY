using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("AT5")]
public class AT5_BillOfLadingHandlingRequirements : EdiX12Segment
{
    [Position(01)]
    public string SpecialHandlingCode { get; set; }

    [Position(02)]
    public string SpecialServicesCode { get; set; }

    [Position(03)]
    public string SpecialHandlingDescription { get; set; }

    [Position(04)]
    public string UnitOrBasisForMeasurementCode { get; set; }

    [Position(05)]
    public decimal? Temperature { get; set; }

    [Position(06)]
    public decimal? Temperature2 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AT5_BillOfLadingHandlingRequirements>(this);
        validator.OnlyOneOf(x => x.SpecialHandlingCode, x => x.SpecialHandlingDescription);
        validator.OnlyOneOf(x => x.SpecialServicesCode, x => x.SpecialHandlingDescription);
        validator.IfOneIsFilledThenAtLeastOne(x => x.UnitOrBasisForMeasurementCode, x => x.Temperature, x => x.Temperature2);
        validator.ARequiresB(x => x.Temperature, x => x.UnitOrBasisForMeasurementCode);
        validator.ARequiresB(x => x.Temperature2, x => x.UnitOrBasisForMeasurementCode);
        validator.Length(x => x.SpecialHandlingCode, 2, 3);
        validator.Length(x => x.SpecialServicesCode, 2, 10);
        validator.Length(x => x.SpecialHandlingDescription, 2, 30);
        validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
        validator.Length(x => x.Temperature, 1, 4);
        validator.Length(x => x.Temperature2, 1, 4);
        return validator.Results;
    }
}