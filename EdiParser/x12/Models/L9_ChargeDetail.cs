using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("L9")]
public class L9_ChargeDetail : EdiX12Segment
{
    [Position(01)]
    public string SpecialChargeOrAllowanceCode { get; set; }

    [Position(02)]
    public decimal? MonetaryAmount { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<L9_ChargeDetail>(this);
        validator.Required(x => x.SpecialChargeOrAllowanceCode);
        validator.Required(x => x.MonetaryAmount);
        validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
        validator.Length(x => x.MonetaryAmount, 1, 18);
        return validator.Results;
    }
}