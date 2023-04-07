using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("Q7")]
public class Q7_LadingExceptionStatus : EdiX12Segment
{
    [Position(01)]
    public string LadingExceptionCode { get; set; }

    [Position(02)]
    public string PackagingFormCode { get; set; }

    [Position(03)]
    public int? LadingQuantity { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<Q7_LadingExceptionStatus>(this);
        validator.Required(x => x.LadingExceptionCode);
        validator.ARequiresB(x => x.PackagingFormCode, x => x.LadingQuantity);
        validator.Length(x => x.LadingExceptionCode, 1);
        validator.Length(x => x.PackagingFormCode, 3);
        validator.Length(x => x.LadingQuantity, 1, 7);
        return validator.Results;
    }
}