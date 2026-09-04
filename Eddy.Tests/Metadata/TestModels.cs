using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models;

namespace Eddy.Tests.Metadata;

/// <summary>
/// No shipped model currently calls VerifyDateFormat/VerifyTimeFormat, so this synthetic segment
/// exercises DerivedSegmentMetadata's date/time detection directly.
/// </summary>
[Segment("XDT")]
public class XDT_DateTimeProbe : EdiX12Segment
{
    [Position(1)]
    public string DateField { get; set; }

    [Position(2)]
    public string TimeField { get; set; }

    [Position(3)]
    public string PlainField { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<XDT_DateTimeProbe>(this);
        validator.VerifyDateFormat(x => x.DateField);
        validator.VerifyTimeFormat(x => x.TimeField);
        validator.Length(x => x.PlainField, 1, 5);
        return validator.Results;
    }
}
