using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._204;

public class Party
{
    [SectionPosition(1)]
    public N1_Name PartyIdentification { get; set; }

    [SectionPosition(2)]
    public N2_AdditionalNameInformation AdditionalNameInformation { get; set; }

    [SectionPosition(3)]
    public List<N3_AddressInformation> PartyLocations { get; set; } = new();

    [SectionPosition(4)]
    public N4_GeographicLocation GeographicLocation { get; set; }

    [SectionPosition(5)]
    public List<N9_ReferenceIdentification> ReferenceInformation { get; set; } = new();

    [SectionPosition(6)]
    public List<G61_Contact> Contacts{ get; set; } = new();

}