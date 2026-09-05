using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact;

/// <summary>UNG - Functional Group Header. Reuses the D96A composites for its S006/S007/S004/S008
/// sub-elements rather than duplicating them, matching how <see cref="GenericInterchangeControlHeader"/>
/// reuses composites for UNB.</summary>
[Segment("UNG")]
public class GenericFunctionalGroupHeader : EdifactSegment
{
    [Position(1)]
    public string FunctionalGroupIdentification { get; set; }

    [Position(2)]
    public Eddy.Edifact.Models.D96A.Composites.S006_ApplicationSendersIdentification ApplicationSendersIdentification { get; set; }

    [Position(3)]
    public Eddy.Edifact.Models.D96A.Composites.S007_ApplicationRecipientsIdentification ApplicationRecipientsIdentification { get; set; }

    [Position(4)]
    public Eddy.Edifact.Models.D96A.Composites.S004_DateTimeOfPreparation DateTimeOfPreparation { get; set; }

    [Position(5)]
    public string FunctionalGroupReferenceNumber { get; set; }

    [Position(6)]
    public string ControllingAgency { get; set; }

    [Position(7)]
    public Eddy.Edifact.Models.D96A.Composites.S008_MessageVersion MessageVersion { get; set; }

    [Position(8)]
    public string ApplicationPassword { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericFunctionalGroupHeader>(this);
        validator.Required(x => x.FunctionalGroupIdentification);
        validator.Required(x => x.ApplicationSendersIdentification);
        validator.Required(x => x.ApplicationRecipientsIdentification);
        validator.Required(x => x.DateTimeOfPreparation);
        validator.Required(x => x.FunctionalGroupReferenceNumber);
        validator.Required(x => x.ControllingAgency);
        validator.Required(x => x.MessageVersion);
        validator.Length(x => x.FunctionalGroupIdentification, 1, 6);
        validator.Length(x => x.FunctionalGroupReferenceNumber, 1, 14);
        validator.Length(x => x.ControllingAgency, 1, 2);
        validator.Length(x => x.ApplicationPassword, 1, 14);
        return validator.Results;
    }
}
