using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C047")]
public class C047_CompositeTypeOfRealEstateAssetCode : EdiX12Component
{
    [Position(00)]
    public string TypeOfRealEstateAssetCode { get; set; }

    [Position(01)]
    public string TypeOfRealEstateAssetCode2 { get; set; }

    [Position(02)]
    public string TypeOfRealEstateAssetCode3 { get; set; }

    [Position(03)]
    public string TypeOfRealEstateAssetCode4 { get; set; }

    [Position(04)]
    public string TypeOfRealEstateAssetCode5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C047_CompositeTypeOfRealEstateAssetCode>(this);
        validator.Required(x => x.TypeOfRealEstateAssetCode);
        validator.ARequiresB(x => x.TypeOfRealEstateAssetCode5, x => x.TypeOfRealEstateAssetCode4);
        validator.Length(x => x.TypeOfRealEstateAssetCode, 2);
        validator.Length(x => x.TypeOfRealEstateAssetCode2, 2);
        validator.Length(x => x.TypeOfRealEstateAssetCode3, 2);
        validator.Length(x => x.TypeOfRealEstateAssetCode4, 2);
        validator.Length(x => x.TypeOfRealEstateAssetCode5, 2);
        return validator.Results;
    }
}