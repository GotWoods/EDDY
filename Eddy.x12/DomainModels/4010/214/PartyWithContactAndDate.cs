using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._214;

public class PartyWithContactAndDate
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
    public G61_Contact Contact { get; set; }

    [SectionPosition(5)]
    public G62_DateTime DateTime { get; set; }

    [SectionPosition(6)]
    public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();
}