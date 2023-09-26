using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._211;

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
    public List<G61_Contact> Contact { get; set; } = new();
    
}