using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C067")]
public class C067_CompositeProductWeightBasis : EdiX12Component
{
    [Position(00)]
    public decimal? UnitWeight { get; set; }

    [Position(01)]
    public string WeightQualifier { get; set; }

    [Position(02)]
    public string WeightUnitCode { get; set; }

    [Position(03)]
    public decimal? UnitWeight2 { get; set; }

    [Position(04)]
    public string WeightQualifier2 { get; set; }

    [Position(05)]
    public string WeightUnitCode2 { get; set; }

    [Position(06)]
    public decimal? UnitWeight3 { get; set; }

    [Position(07)]
    public string WeightQualifier3 { get; set; }

    [Position(08)]
    public string WeightUnitCode3 { get; set; }

    [Position(09)]
    public decimal? UnitWeight4 { get; set; }

    [Position(10)]
    public string WeightQualifier4 { get; set; }

    [Position(11)]
    public string WeightUnitCode4 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C067_CompositeProductWeightBasis>(this);
        validator.Required(x => x.UnitWeight);
        validator.Required(x => x.WeightQualifier);
        validator.Required(x => x.WeightUnitCode);
        validator.Length(x => x.UnitWeight, 1, 8);
        validator.Length(x => x.WeightQualifier, 1, 2);
        validator.Length(x => x.WeightUnitCode, 1);
        validator.Length(x => x.UnitWeight2, 1, 8);
        validator.Length(x => x.WeightQualifier2, 1, 2);
        validator.Length(x => x.WeightUnitCode2, 1);
        validator.Length(x => x.UnitWeight3, 1, 8);
        validator.Length(x => x.WeightQualifier3, 1, 2);
        validator.Length(x => x.WeightUnitCode3, 1);
        validator.Length(x => x.UnitWeight4, 1, 8);
        validator.Length(x => x.WeightQualifier4, 1, 2);
        validator.Length(x => x.WeightUnitCode4, 1);
        return validator.Results;
    }
}