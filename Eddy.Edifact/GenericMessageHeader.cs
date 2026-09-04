using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact;

/// <summary>UNH - Message Header. Field layout and the S009 identifier composite are stable from D96A
/// onward (see "Generic Header Info.txt"), so - like <see cref="GenericInterchangeControlHeader"/> does
/// for UNB - this reuses the D96A composite type rather than defining a new one. Parsed before the
/// message's own version is known/resolved, so its shape must not depend on that version.</summary>
[Segment("UNH")]
public class GenericMessageHeader : EdifactSegment
{
    [Position(1)]
    public string MessageReferenceNumber { get; set; }

    [Position(2)]
    public Eddy.Edifact.Models.D96A.Composites.S009_MessageIdentifier MessageIdentifier { get; set; }

    [Position(3)]
    public string CommonAccessReference { get; set; }

    [Position(4)]
    public Eddy.Edifact.Models.D96A.Composites.S010_StatusOfTheTransfer StatusOfTheTransfer { get; set; }

    /// <summary>The message's standards version, e.g. "D96A" (MessageVersionNumber + MessageReleaseNumber
    /// from the S009 composite), or "" when the composite/its fields were not present.</summary>
    public string Version =>
        (MessageIdentifier?.MessageVersionNumber ?? "") + (MessageIdentifier?.MessageReleaseNumber ?? "");

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericMessageHeader>(this);
        validator.Required(x => x.MessageReferenceNumber);
        validator.Required(x => x.MessageIdentifier);
        validator.Length(x => x.MessageReferenceNumber, 1, 14);
        validator.Length(x => x.CommonAccessReference, 1, 35);
        return validator.Results;
    }
}
