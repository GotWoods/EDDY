using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("ADX")]
public class ADX_Adjustment : EdiX12Segment
{
    [Position(01)] public decimal? MonetaryAmount { get; set; }

    [Position(02)] public string AdjustmentReasonCode { get; set; }

    [Position(03)] public string ReferenceIdentificationQualifier { get; set; }

    [Position(04)] public string ReferenceIdentification { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ADX_Adjustment>(this);
        validator.Required(x => x.MonetaryAmount);
        validator.Required(x => x.AdjustmentReasonCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.ReferenceIdentificationQualifier, x => x.ReferenceIdentification);
        validator.Length(x => x.MonetaryAmount, 1, 18);
        validator.Length(x => x.AdjustmentReasonCode, 2);
        validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
        validator.Length(x => x.ReferenceIdentification, 1, 80);
        return validator.Results;
    }
}