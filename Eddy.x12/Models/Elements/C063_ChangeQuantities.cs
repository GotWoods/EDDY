using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C063")]
public class C063_ChangeQuantities : EdiX12Component
{
    [Position(00)]
    public decimal? Quantity { get; set; }

    [Position(01)]
    public decimal? Quantity2 { get; set; }

    [Position(02)]
    public decimal? Quantity3 { get; set; }

    [Position(03)]
    public decimal? Quantity4 { get; set; }

    [Position(04)]
    public decimal? Quantity5 { get; set; }

    [Position(05)]
    public decimal? Quantity6 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C063_ChangeQuantities>(this);
        validator.OnlyOneOf(x => x.Quantity2, x => x.Quantity3);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.Quantity2, 1, 15);
        validator.Length(x => x.Quantity3, 1, 15);
        validator.Length(x => x.Quantity4, 1, 15);
        validator.Length(x => x.Quantity5, 1, 15);
        validator.Length(x => x.Quantity6, 1, 15);
        return validator.Results;
    }
}