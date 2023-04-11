using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("AK4")]
public class AK4_DataElementNote : EdiX12Segment
{
    [Position(01)]
    public C030_PositionInSegment PositionInSegment { get; set; }

    [Position(02)]
    public string DataElementReferenceCode { get; set; }

    [Position(03)]
    public string DataElementSyntaxErrorCode { get; set; }

    [Position(04)]
    public string CopyOfBadDataElement { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AK4_DataElementNote>(this);
        validator.Required(x => x.PositionInSegment);
        validator.Required(x => x.DataElementSyntaxErrorCode);
        validator.Length(x => x.DataElementReferenceCode, 1, 4);
        validator.Length(x => x.DataElementSyntaxErrorCode, 1, 3);
        validator.Length(x => x.CopyOfBadDataElement, 1, 99);
        return validator.Results;
    }
}