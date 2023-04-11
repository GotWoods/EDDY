using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C058")]
public class C058_AdjustmentReason : EdiX12Component
{
    [Position(00)]
    public string ClaimAdjustmentReasonCode { get; set; }

    [Position(01)]
    public string CodeListQualifierCode { get; set; }

    [Position(02)]
    public string IndustryCode { get; set; }

    [Position(03)]
    public string IndustryCode2 { get; set; }

    [Position(04)]
    public string IndustryCode3 { get; set; }

    [Position(05)]
    public string IndustryCode4 { get; set; }

    [Position(06)]
    public string IndustryCode5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C058_AdjustmentReason>(this);
        validator.Required(x => x.ClaimAdjustmentReasonCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.CodeListQualifierCode, x => x.IndustryCode);
        validator.ARequiresB(x => x.IndustryCode2, x => x.IndustryCode);
        validator.ARequiresB(x => x.IndustryCode3, x => x.IndustryCode2);
        validator.ARequiresB(x => x.IndustryCode4, x => x.IndustryCode3);
        validator.ARequiresB(x => x.IndustryCode5, x => x.IndustryCode4);
        validator.Length(x => x.ClaimAdjustmentReasonCode, 1, 5);
        validator.Length(x => x.CodeListQualifierCode, 1, 3);
        validator.Length(x => x.IndustryCode, 1, 30);
        validator.Length(x => x.IndustryCode2, 1, 30);
        validator.Length(x => x.IndustryCode3, 1, 30);
        validator.Length(x => x.IndustryCode4, 1, 30);
        validator.Length(x => x.IndustryCode5, 1, 30);
        return validator.Results;
    }
}