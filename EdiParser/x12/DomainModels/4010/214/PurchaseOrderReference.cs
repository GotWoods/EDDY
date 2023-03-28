using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._214;

public class PurchaseOrderReference
{
    [SectionPosition(1)]
    public PRF_PurchaseOrderReference Detail { get; set; }

    [SectionPosition(2)]
    public List<Party> Parties { get; set; } = new();

    [SectionPosition(3)]
    public List<PurchaseOrderCartonDetail> PurchaseOrderCartonDetails { get; set; } = new();
}