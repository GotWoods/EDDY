using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C024")]
public class C024_RelatedCausesInformation : EdiX12Component
{
    [Position(00)]
    public string RelatedCausesCode { get; set; }

    [Position(01)]
    public string RelatedCausesCode2 { get; set; }

    [Position(02)]
    public string RelatedCausesCode3 { get; set; }

    [Position(03)]
    public string StateOrProvinceCode { get; set; }

    [Position(04)]
    public string CountryCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C024_RelatedCausesInformation>(this);
        validator.Required(x => x.RelatedCausesCode);
        validator.Length(x => x.RelatedCausesCode, 2, 3);
        validator.Length(x => x.RelatedCausesCode2, 2, 3);
        validator.Length(x => x.RelatedCausesCode3, 2, 3);
        validator.Length(x => x.StateOrProvinceCode, 2);
        validator.Length(x => x.CountryCode, 2, 3);
        return validator.Results;
    }
}