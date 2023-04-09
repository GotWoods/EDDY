using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("ACT")]
public class ACT_AccountIdentification : EdiX12Segment
{
    [Position(01)] public string AccountNumber { get; set; }

    [Position(02)] public string Name { get; set; }

    [Position(03)] public string IdentificationCodeQualifier { get; set; }

    [Position(04)] public string IdentificationCode { get; set; }

    [Position(05)] public string AccountNumberQualifier { get; set; }

    [Position(06)] public string AccountNumber2 { get; set; }

    [Position(07)] public string Description { get; set; }

    [Position(08)] public string PaymentMethodTypeCode { get; set; }

    [Position(09)] public string BenefitStatusCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ACT_AccountIdentification>(this);
        validator.Required(x => x.AccountNumber);
        validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCodeQualifier, x => x.IdentificationCode);
        validator.ARequiresB(x => x.AccountNumberQualifier, x => x.AccountNumber2);
        validator.ARequiresB(x => x.Description, x => x.AccountNumberQualifier);
        validator.Length(x => x.AccountNumber, 1, 35);
        validator.Length(x => x.Name, 1, 60);
        validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
        validator.Length(x => x.IdentificationCode, 2, 80);
        validator.Length(x => x.AccountNumberQualifier, 1, 3);
        validator.Length(x => x.AccountNumber2, 1, 35);
        validator.Length(x => x.Description, 1, 80);
        validator.Length(x => x.PaymentMethodTypeCode, 1, 2);
        validator.Length(x => x.BenefitStatusCode, 1);
        return validator.Results;
    }
}