using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("H2")]
public class H2_AdditionalHazardousMaterialDescription : EdiX12Segment
{
    [Position(01)]
    public string HazardousMaterialDescription { get; set; }

    [Position(02)]
    public string HazardousMaterialClassification { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<H2_AdditionalHazardousMaterialDescription>(this);
        validator.Required(x => x.HazardousMaterialDescription);
        validator.Length(x => x.HazardousMaterialDescription, 2, 30);
        validator.Length(x => x.HazardousMaterialClassification, 1, 30);
        return validator.Results;
    }
}