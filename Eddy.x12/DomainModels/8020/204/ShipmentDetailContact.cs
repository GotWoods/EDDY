using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._8020._204;

public class ShipmentDetailContact
{
    [SectionPosition(1)]
    public G61_Contact Info { get; set; }

    [SectionPosition(2)]
    public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();

    [SectionPosition(3)]
    public List<LH6_HazardousCertification> HazardosCertifications { get; set; } = new();

    [SectionPosition(4)]
    public List<HazMatInfo> HazMatInfo { get; set; } = new();
}