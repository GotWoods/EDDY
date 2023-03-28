using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._214;

public class PurchaseOrderCartonDetail
{
    [SectionPosition(1)]
    public CD3_CartonPackageDetail CartonPackageDetail { get; set; }

    [SectionPosition(2)]
    public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();

    [SectionPosition(3)]
    public List<ShipmentStatusDetails> ShipmentStatusDetails { get; set; } = new();


    [SectionPosition(4)]
    public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
}