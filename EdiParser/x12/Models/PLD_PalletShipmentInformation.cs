using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("PLD")]
public class PLD_PalletShipmentInformation : EdiX12Segment
{
    [Position(01)]
    public int? QuantityOfPalletsShipped { get; set; }

    [Position(02)]
    public string PalletExchangeCode { get; set; }

    [Position(03)]
    public string WeightUnitCode { get; set; }

    [Position(04)]
    public decimal? Weight { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<PLD_PalletShipmentInformation>(this);
        validator.Required(x => x.QuantityOfPalletsShipped);
        validator.IfOneIsFilled_AllAreRequired(x => x.WeightUnitCode, x => x.Weight);
        validator.Length(x => x.QuantityOfPalletsShipped, 1, 3);
        validator.Length(x => x.PalletExchangeCode, 1);
        validator.Length(x => x.WeightUnitCode, 1);
        validator.Length(x => x.Weight, 1, 10);
        return validator.Results;
    }
}