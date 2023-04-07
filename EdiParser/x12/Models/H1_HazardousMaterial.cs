using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("H1")]
public class H1_HazardousMaterial : EdiX12Segment
{
    [Position(01)]
    public string HazardousMaterialCode { get; set; }

    [Position(02)]
    public string HazardousMaterialClassCode { get; set; }

    [Position(03)]
    public string HazardousMaterialCodeQualifier { get; set; }

    [Position(04)]
    public string HazardousMaterialDescription { get; set; }

    [Position(05)]
    public string HazardousMaterialContact { get; set; }

    [Position(06)]
    public string HazardousMaterialsPage { get; set; }

    [Position(07)]
    public int? FlashpointTemperature { get; set; }

    [Position(08)]
    public string UnitOrBasisForMeasurementCode { get; set; }

    [Position(09)]
    public string PackingGroupCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<H1_HazardousMaterial>(this);
        validator.Required(x => x.HazardousMaterialCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.FlashpointTemperature, x => x.UnitOrBasisForMeasurementCode);
        validator.Length(x => x.HazardousMaterialCode, 4, 10);
        validator.Length(x => x.HazardousMaterialClassCode, 1, 4);
        validator.Length(x => x.HazardousMaterialCodeQualifier, 1);
        validator.Length(x => x.HazardousMaterialDescription, 2, 30);
        validator.Length(x => x.HazardousMaterialContact, 1, 24);
        validator.Length(x => x.HazardousMaterialsPage, 1, 6);
        validator.Length(x => x.FlashpointTemperature, 1, 3);
        validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
        validator.Length(x => x.PackingGroupCode, 1, 3);
        return validator.Results;
    }
}