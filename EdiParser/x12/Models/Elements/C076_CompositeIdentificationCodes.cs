using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C076")]
public class C076_CompositeIdentificationCodes : EdiX12Component
{
    [Position(00)]
    public string IdentificationCodeQualifier { get; set; }

    [Position(01)]
    public string IdentificationCode { get; set; }

    [Position(02)]
    public string IdentificationCodeQualifier2 { get; set; }

    [Position(03)]
    public string IdentificationCode2 { get; set; }

    [Position(04)]
    public string IdentificationCodeQualifier3 { get; set; }

    [Position(05)]
    public string IdentificationCode3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C076_CompositeIdentificationCodes>(this);
        validator.Required(x => x.IdentificationCodeQualifier);
        validator.Required(x => x.IdentificationCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCodeQualifier2, x => x.IdentificationCode2);
        validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCodeQualifier3, x => x.IdentificationCode3);
        validator.ARequiresB(x => x.IdentificationCodeQualifier3, x => x.IdentificationCodeQualifier2);
        validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
        validator.Length(x => x.IdentificationCode, 2, 80);
        validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
        validator.Length(x => x.IdentificationCode2, 2, 80);
        validator.Length(x => x.IdentificationCodeQualifier3, 1, 2);
        validator.Length(x => x.IdentificationCode3, 2, 80);
        return validator.Results;
    }
}