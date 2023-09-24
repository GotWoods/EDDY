using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C078")]
public class C078_CompositeDangerousGoodsSubsidiaryClassificationCodes : EdiX12Component
{
    [Position(01)]
    public string SubsidiaryClassificationCode { get; set; }

    [Position(02)]
    public string SubsidiaryClassificationCode2 { get; set; }

    [Position(03)]
    public string SubsidiaryClassificationCode3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C078_CompositeDangerousGoodsSubsidiaryClassificationCodes>(this);
        validator.Required(x => x.SubsidiaryClassificationCode);
        validator.ARequiresB(x => x.SubsidiaryClassificationCode3, x => x.SubsidiaryClassificationCode2);
        validator.Length(x => x.SubsidiaryClassificationCode, 1, 4);
        validator.Length(x => x.SubsidiaryClassificationCode2, 1, 4);
        validator.Length(x => x.SubsidiaryClassificationCode3, 1, 4);
        return validator.Results;
    }
}