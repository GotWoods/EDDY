using Eddy.Core.Attributes;
using Eddy.Core.Codes;
using Eddy.Core.Validation;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Codes;

/// <summary>A minimal code list used only by <see cref="ZZC_CodeMappingTestSegment"/> to exercise how
/// Eddy.x12.Mapping.Map reads and writes a Code&lt;TList&gt; property. No shipped segment uses
/// Code&lt;TList&gt; yet, so this is defined here rather than reusing a real model.</summary>
public sealed class ZZCTestCodes : CodeList
{
    public override string Standard => "X12";
    public override string DataElementNumber => "9999";
    public override string Name => "Test Entity Code";
}

[Segment("ZZC")]
public class ZZC_CodeMappingTestSegment : EdiX12Segment
{
    [Position(1)]
    public Code<ZZCTestCodes> EntityCode { get; set; }

    [Position(2)]
    public string Plain { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ZZC_CodeMappingTestSegment>(this);
        return validator.Results;
    }
}
