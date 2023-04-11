using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C048")]
public class C048_CompositeUseOfProceeds : EdiX12Component
{
    [Position(00)]
    public string UseOfProceedsCode { get; set; }

    [Position(01)]
    public string RefinanceTypeCode { get; set; }

    [Position(02)]
    public string UseOfProceedsCode2 { get; set; }

    [Position(03)]
    public string YesNoConditionOrResponseCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C048_CompositeUseOfProceeds>(this);
        validator.Required(x => x.UseOfProceedsCode);
        validator.Length(x => x.UseOfProceedsCode, 2);
        validator.Length(x => x.RefinanceTypeCode, 2);
        validator.Length(x => x.UseOfProceedsCode2, 2);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        return validator.Results;
    }
}