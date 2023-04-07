using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.x12.DomainModels._211;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._211
{
    public class BillOfLadingLine
    {
        [SectionPosition(1)] public AT1_BillOfLadingLineItemNumber BillOfLadingLineItemNumber { get; set; }
        [SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();
        [SectionPosition(3)] public AT3_BillOfLadingRatesAndCharges RatesAndCharges { get; set; }
        [SectionPosition(4)] public List<AT4_BillOfLadingDescription> Description { get; set; } = new();
        [SectionPosition(5)] public LineDetail LineDetail { get; set; }
        [SectionPosition(6)] public List<Numbers> Numbers { get; set; } = new();
        [SectionPosition(7)] public List<HazMatContact> HazMatContacts{ get; set; } = new();

    }
}
