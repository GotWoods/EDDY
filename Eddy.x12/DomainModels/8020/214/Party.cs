using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels._8020._214;

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
    public G62_DateTime DateTime { get; set; }

    [SectionPosition(6)]
    public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();


}