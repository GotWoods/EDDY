using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C023")]
public class C023_HealthCareServiceLocationInformation : EdiX12Component
{
    [Position(00)]
    public string FacilityCodeValue { get; set; }

    [Position(01)]
    public string FacilityCodeQualifier { get; set; }

    [Position(02)]
    public string ClaimFrequencyTypeCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C023_HealthCareServiceLocationInformation>(this);
        validator.Required(x => x.FacilityCodeValue);
        validator.Required(x => x.FacilityCodeQualifier);
        validator.Length(x => x.FacilityCodeValue, 1, 3);
        validator.Length(x => x.FacilityCodeQualifier, 1, 2);
        validator.Length(x => x.ClaimFrequencyTypeCode, 1);
        return validator.Results;
    }
}