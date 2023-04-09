using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("PKG")]
public class PKG_MarkingPackagingLoading : EdiX12Segment
{
    [Position(01)]
    public string ItemDescriptionTypeCode { get; set; }

    [Position(02)]
    public string PackagingCharacteristicCode { get; set; }

    [Position(03)]
    public string AgencyQualifierCode { get; set; }

    [Position(04)]
    public string PackagingDescriptionCode { get; set; }

    [Position(05)]
    public string Description { get; set; }

    [Position(06)]
    public string UnitLoadOptionCode { get; set; }

    [Position(07)]
    public string LanguageCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<PKG_MarkingPackagingLoading>(this);
        validator.ARequiresB(x => x.PackagingDescriptionCode, x => x.AgencyQualifierCode);
        validator.ARequiresB(x => x.Description, x => x.ItemDescriptionTypeCode);
        validator.ARequiresB(x => x.LanguageCode, x => x.Description);
        validator.Length(x => x.ItemDescriptionTypeCode, 1);
        validator.Length(x => x.PackagingCharacteristicCode, 1, 5);
        validator.Length(x => x.AgencyQualifierCode, 2);
        validator.Length(x => x.PackagingDescriptionCode, 1, 7);
        validator.Length(x => x.Description, 1, 80);
        validator.Length(x => x.UnitLoadOptionCode, 2);
        validator.Length(x => x.LanguageCode, 2, 3);
        return validator.Results;
    }
}