using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C035")]
public class C035_ProviderSpecialtyInformation : EdiX12Component
{
    [Position(00)]
    public string ProviderSpecialtyCode { get; set; }

    [Position(01)]
    public string AgencyQualifierCode { get; set; }

    [Position(02)]
    public string YesNoConditionOrResponseCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C035_ProviderSpecialtyInformation>(this);
        validator.Required(x => x.ProviderSpecialtyCode);
        validator.Length(x => x.ProviderSpecialtyCode, 1, 3);
        validator.Length(x => x.AgencyQualifierCode, 2);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        return validator.Results;
    }
}