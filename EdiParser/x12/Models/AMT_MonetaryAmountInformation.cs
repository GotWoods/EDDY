using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("AMT")]
public class AMT_MonetaryAmountInformation : EdiX12Segment
{
    [Position(01)] public string AmountQualifierCode { get; set; }

    [Position(02)] public decimal? MonetaryAmount { get; set; }

    [Position(03)] public string CreditDebitFlagCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AMT_MonetaryAmountInformation>(this);
        validator.Required(x => x.AmountQualifierCode);
        validator.Required(x => x.MonetaryAmount);
        validator.Length(x => x.AmountQualifierCode, 1, 3);
        validator.Length(x => x.MonetaryAmount, 1, 18);
        validator.Length(x => x.CreditDebitFlagCode, 1);
        return validator.Results;
    }
}