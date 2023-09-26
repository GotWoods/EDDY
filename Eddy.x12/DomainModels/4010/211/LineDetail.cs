using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._211;

public class LineDetail
{
    [SectionPosition(1)] public AT2_BillOfLadingLineItemDetail Detail { get; set; }
    [SectionPosition(2)] public List<MAN_MarksAndNumbers> MarksAndNumbersInformation { get; set; } = new();
    [SectionPosition(3)] public List<SPO_ShipmentPurchaseOrderDetail> ShipmentPurchaseOrderDetail { get; set; } = new();
}