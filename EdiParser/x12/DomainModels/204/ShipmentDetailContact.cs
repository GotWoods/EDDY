using System.Collections;
using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class ShipmentDetailContact
{
    public G61_Contact Info { get; set; }
    public List<HazMatInfo> HazMatInfo { get; set; } = new();
    public List<LH6_HazardousCertification> HazardosCertifications { get; set; } = new();
}