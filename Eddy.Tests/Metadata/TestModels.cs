using Eddy.Core.Attributes;
using Eddy.Core.Codes;
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

/// <summary>A minimal code list used only by <see cref="XCD_CodeProbe"/>, below, to exercise how
/// DerivedSegmentMetadata reports a Code&lt;TList&gt; property.</summary>
public sealed class XCD_TestCodes : CodeList
{
    public override string Standard => "X12";
    public override string DataElementNumber => "9999";
    public override string Name => "Test Code List";
}

/// <summary>No shipped model currently has a Code&lt;TList&gt; property, so this synthetic segment
/// exercises DerivedSegmentMetadata's handling of one directly.</summary>
[Segment("XCD")]
public class XCD_CodeProbe : EdiX12Segment
{
    [Position(1)]
    public Code<XCD_TestCodes> EntityCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<XCD_CodeProbe>(this);
        return validator.Results;
    }
}
