using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C999")]
public class C999_ReferenceInSegment : EdiX12Component
{
    [Position(00)]
    public string DataElementReferenceCode { get; set; }

    [Position(01)]
    public string DataElementReferenceCode2 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C999_ReferenceInSegment>(this);
        validator.Required(x => x.DataElementReferenceCode);
        validator.Length(x => x.DataElementReferenceCode, 1, 4);
        validator.Length(x => x.DataElementReferenceCode2, 1, 4);
        return validator.Results;
    }
}