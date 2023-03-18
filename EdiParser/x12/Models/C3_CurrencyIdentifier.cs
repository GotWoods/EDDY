using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("C3")]
public class C3_CurrencyIdentifier : EdiX12Segment
{
    [Position(01)]
    public string CurrencyCode { get; set; }

    [Position(02)]
    public string ExchangeRate { get; set; }

    [Position(03)]
    public string CurrencyCode2 { get; set; }

    [Position(04)]
    public string CurrencyCode3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C3_CurrencyIdentifier>(this);
        validator.Required(x => x.CurrencyCode);
        validator.Length(x => x.CurrencyCode, 3);
        validator.Length(x => x.ExchangeRate, 4, 10);
        validator.Length(x => x.CurrencyCode2, 3);
        validator.Length(x => x.CurrencyCode3, 3);
        return validator.Results;
    }
}