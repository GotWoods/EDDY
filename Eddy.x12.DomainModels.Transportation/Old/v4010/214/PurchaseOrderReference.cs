using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._214;

public class PurchaseOrderReference
{
    [SectionPosition(1)]
    public PRF_PurchaseOrderReference Detail { get; set; }

    [SectionPosition(2)]
    public List<Party> Parties { get; set; } = new();

    [SectionPosition(3)]
    public List<PurchaseOrderCartonDetail> PurchaseOrderCartonDetails { get; set; } = new();
}