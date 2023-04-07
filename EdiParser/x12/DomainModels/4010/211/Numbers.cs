using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._211;

public class Numbers
{
    [SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; }
    [SectionPosition(2)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbers { get; set; } = new();
    [SectionPosition(3)] public List<SPO_ShipmentPurchaseOrderDetail> ShipmentPurchaseOrderDetail { get; set; } = new();
}