using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("AT3")]
public class AT3_BillOfLadingRatesAndCharges : EdiX12Segment
{
    [Position(01)]
    public string AmountCharged { get; set; }

    [Position(02)]
    public string FreightRateQualifier { get; set; }

    [Position(03)]
    public decimal? FreightRate { get; set; }

    [Position(04)]
    public string RatedAsQualifier { get; set; }

    [Position(05)]
    public decimal? Quantity { get; set; }

    [Position(06)]
    public string BillOfLadingChargeCode { get; set; }

    [Position(07)]
    public decimal? PercentageAsDecimal { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AT3_BillOfLadingRatesAndCharges>(this);
        validator.Required(x => x.AmountCharged);
        validator.IfOneIsFilled_AllAreRequired(x => x.FreightRateQualifier, x => x.FreightRate);
        validator.IfOneIsFilled_AllAreRequired(x => x.RatedAsQualifier, x => x.Quantity);
        validator.ARequiresB(x => x.RatedAsQualifier, x => x.FreightRateQualifier);
        validator.Length(x => x.AmountCharged, 1, 15);
        validator.Length(x => x.FreightRateQualifier, 2);
        validator.Length(x => x.FreightRate, 1, 15);
        validator.Length(x => x.RatedAsQualifier, 2);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.BillOfLadingChargeCode, 3);
        validator.Length(x => x.PercentageAsDecimal, 1, 10);
        return validator.Results;
    }
}