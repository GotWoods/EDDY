using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C030")]
public class C030_PositionInSegment : EdiX12Component
{
    [Position(00)]
    public int? ElementPositionInSegment { get; set; }

    [Position(01)]
    public int? ComponentDataElementPositionInComposite { get; set; }

    [Position(02)]
    public int? RepeatingDataElementPosition { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C030_PositionInSegment>(this);
        validator.Required(x => x.ElementPositionInSegment);
        validator.Length(x => x.ElementPositionInSegment, 1, 2);
        validator.Length(x => x.ComponentDataElementPositionInComposite, 1, 2);
        validator.Length(x => x.RepeatingDataElementPosition, 1, 4);
        return validator.Results;
    }
}