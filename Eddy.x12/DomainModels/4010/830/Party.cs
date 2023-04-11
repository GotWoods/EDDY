using System;
using System.Collections.Generic;
using System.Text;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._4010._830;

public class Party
{
    [SectionPosition(1)]
    public N1_PartyIdentification PartyIdentification { get; set; }

    [SectionPosition(2)]
    public N2_AdditionalNameInformation AdditionalNameInformation { get; set; }

    [SectionPosition(3)]
    public List<N3_PartyLocation> PartyLocations { get; set; } = new();

    [SectionPosition(4)]
    public N4_GeographicLocation GeographicLocation { get; set; }

    [SectionPosition(5)]
    public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();

    [SectionPosition(5)]
    public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContacts { get; set; } = new();

    [SectionPosition(5)]
    public List<FOB_RelatedInstructions> FobRelatedInstructions{ get; set; } = new();
}